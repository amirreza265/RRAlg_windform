using ProgressBarSample;
using RRAlg_windform.Classes;
using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace RRAlg_windform
{
    public partial class Form1 : Form
    {
        private RoundRobinList<TextProgressBar> _processes;
        private List<Tuple<string, int, ulong>> _processEnded;
        private List<Tuple<string, int>> _backupProcess;

        private Thread _timer;
        private bool _timerEnabled = false;
        private int _totalPBar = 0;

        private int _quantomTime = 100;

        private Color _activeColor = Color.Blue, _sleepColor = Color.LightBlue;

        private int[] _customColors = new int[0];

        /// <summary>
        /// first AWT
        /// second Quantom
        /// </summary>
        public event Action<double, double> OnFinish = (awt, quantom) => { };
        public event Action OnGetNext = () => { };

        public int Quantom
        {
            get => _processes.Quantom;
            set => _processes.Quantom = value;
        }
        public int QuantomTime { get => _quantomTime; set => _quantomTime = value; }
        public bool TimerEnabled { get => _timerEnabled; set => _timerEnabled = value; }
        public int TotalPBar { get => _totalPBar; private set => _totalPBar = value; }

        public Form1()
        {
            InitializeComponent();
            toolStriptxtPanelSize_KeyDown(null, new KeyEventArgs(keyData: Keys.Enter));
            _processes = new RoundRobinList<TextProgressBar>();
            _processEnded = new List<Tuple<string, int, ulong>>();
            _backupProcess = new List<Tuple<string, int>>();

            QuantomTime = (int)txtQTime.Value;

            RRItem<TextProgressBar>? lastProcess = null;
            _processes.OnGetNext += (q, item, removed) =>
            {
                item.Data.Invoke(() =>
                {
                    //Return last process 'Color' back to the previous color after quantom
                    if (lastProcess is null)
                    {
                        lastProcess = item;
                        return;
                    }

                    lastProcess?.Data.Invoke(() =>
                    {
                        lastProcess!.Data.ProgressColor = _sleepColor;
                    });

                    lastProcess = item;

                    //change progressbar to new value
                    var c = item.Data.ProgressColor;
                    item.Data.Value = (int)(item.CompletePercentage() * 100d);
                    item.Data.CustomText = $"{txtProcessName.Text}({item.InitialWeight}): Wait({item.TotalWaitingTime}), P({item.Weight})";
                    //change color to show active process
                    item.Data.ProgressColor = _activeColor;

                });

                if (removed)
                {
                    ProcessesListView.Invoke(() =>
                    {
                        _processEnded.Add(new Tuple<string, int, ulong>(item.Data.CustomText, item.InitialWeight, item.TotalWaitingTime));
                        Thread.Sleep(QuantomTime);
                        if (ProcessesListView.Controls.Contains(item.Data))
                            ProcessesListView.Controls.Remove(item.Data);
                    });

                    CalculateWSR();
                    SetCount();
                }

                new Thread(CalculatePBarTotal).Start();
                OnGetNext();
            };
        }

        private void toolStriptxtPanelSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            var text = toolStriptxtPanelSize.TextBox.Text;

            text = text.Trim('%');

            int percent = -1;
            int.TryParse(text, out percent);

            if (percent < 30 || percent > 100)
                return;

            ProcessesPanel.Width = percent * this.Width / 100;

            toolStriptxtPanelSize.TextBox.Text = $"{text}%";
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            toolStriptxtPanelSize_KeyDown(null, new KeyEventArgs(keyData: Keys.Enter));
        }

        private void btnAddProcess_Click(object sender, EventArgs e)
        {
            var time = (int)txtProcessTime.Value;
            var name = txtProcessName.Text;

            AddProcess(name, time);
            _backupProcess.Add(new Tuple<string, int>(name, time));
        }

        public void AddProcess(string name, int time)
        {
            var bar = new TextProgressBar()
            {
                Dock = DockStyle.Top,
                CustomText = $"{name}({time}):",
                Value = 0,
                VisualMode = ProgressBarDisplayMode.CustomText,
                Minimum = 0,
                Maximum = 100,
                ProgressColor = _sleepColor
            };

            _processes.AddItem(bar, time);

            ProcessesListView.Invoke(() =>
            {
                ProcessesListView.Controls.Add(bar);
            });

            SetCount();
        }

        public void FillFromBackup()
        {
            foreach (var item in _backupProcess)
            {
                AddProcess(item.Item1, item.Item2);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartOrStop();
        }

        public bool StartOrStop()
        {
            TimerEnabled = !TimerEnabled;

            btnStart.Invoke(() =>
            {
                btnStart.Text = (TimerEnabled) ? "Stop" : "Start";
            });

            txtQTime.Invoke(() =>
            {
                txtQTime.Enabled = !TimerEnabled;
            });

            if (TimerEnabled)
            {
                _timer = new Thread(Timer);
                _timer.IsBackground = true;
                _timer.Start();
            }

            return TimerEnabled;
        }

        private void Timer()
        {
            while (TimerEnabled)
            {
                _processes.GetNext();

                //call on finish
                if (_processes.Count <= 0)
                    break;

                Thread.Sleep(QuantomTime);
            }

            if (_processes.Count <= 0)
            {
                float ast, awt, art;
                GetWSR(out awt, out ast, out art);

                StartOrStop();
                OnFinish(awt, _processes.Quantom);
            }
        }

        private void txtQTime_ValueChanged(object sender, EventArgs e)
        {
            QuantomTime = (int)txtQTime.Value;
        }

        private void CalculateWSR()
        {
            new Thread(() =>
            {
                int count;
                float ast, awt, art;
                count = GetWSR(out awt, out ast, out art);

                panelStatus.Invoke(() =>
                {
                    lblCompletedProcesses.Text = count.ToString();
                    lblAWT.Text = awt.ToString("00.00 q");
                    lblAST.Text = ast.ToString("00.00 q");
                    lblART.Text = art.ToString("00.00 q");
                });

            }).Start();
        }


        /// <returns>Count of Elements</returns>
        private int GetWSR(out float awt, out float ast, out float art)
        {
            var rTime = _processEnded.Sum(i => i.Item2);
            int count = _processEnded.Count;
            var wTime = _processEnded.Sum(p => (long)p.Item3);

            ast = (float)rTime / count;
            awt = (float)wTime / count;
            art = awt + ast;

            return count;
        }

        private void SetCount()
        {
            new Thread(() =>
                toolStrip1.Invoke(() =>
                {
                    stLblCount.Text = $"Count:{_processes.Count}";
                })
            ).Start();
        }

        private void activeProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog())
            {
                colorDialog.CustomColors = _customColors;
                colorDialog.Color = _activeColor;
                var result = colorDialog.ShowDialog();

                _customColors = colorDialog.CustomColors;
                if (result == DialogResult.OK)
                    _activeColor = colorDialog.Color;
            }
        }

        private void sleepProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog())
            {
                colorDialog.CustomColors = _customColors;
                colorDialog.Color = _sleepColor;
                var result = colorDialog.ShowDialog();

                _customColors = colorDialog.CustomColors;
                if (result == DialogResult.OK)
                    _sleepColor = colorDialog.Color;
            }
        }

        private void txtProcessName_TextChanged(object sender, EventArgs e)
        {
            btnAddProcess.Enabled = txtProcessName.Text.Length > 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetCount();
            txtProcessName_TextChanged(null, null);
        }

        private void CalculatePBarTotal()
        {
            var sumPercent = 0;
            try
            {
                sumPercent = _processes.GetAllData().Sum(p => p.Value);
            }
            catch
            {
                return;
            }

            var endedSum = _processEnded.Count * 100;

            var totCount = (_processes.Count + _processEnded.Count);

            if (totCount <= 0)
                return;

            var total = (sumPercent + endedSum) / totCount;

            if (total is > 100 or < 0)
                return;

            TotalPBar = total;

            toolStrip1.Invoke(() =>
            {
                pbarTotal.Value = TotalPBar;
            });
        }


        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void chartOfAWTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChartForm chart = new ChartForm(this);

            chart.Show();
        }

        public void Reset()
        {
            _processes.Clear();
            _processEnded.Clear();

            panelStatus.Invoke(() =>
            {
                lblCompletedProcesses.Text = string.Empty;
                lblAWT.Text = string.Empty;
                lblAST.Text = string.Empty;
                lblART.Text = string.Empty;
            });

            this.Invoke(() =>
            {
                txtProcessName.Text = string.Empty;
                txtProcessTime.Value = 1;
            });
        }
    }
}