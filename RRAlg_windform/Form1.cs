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

        private Thread _timer;
        private bool _timerEnabled = false;

        private int _quantomTime = 100;


        public Form1()
        {
            InitializeComponent();
            toolStriptxtPanelSize_KeyDown(null, new KeyEventArgs(keyData: Keys.Enter));
            _processes = new RoundRobinList<TextProgressBar>();
            _processEnded = new List<Tuple<string, int, ulong>>();
            _quantomTime = (int)txtQTime.Value;

            _processes.OnGetNext += (q, item, removed) =>
            {
                item.Data.Invoke(() =>
                {
                    //change progressbar to new value
                    var c = item.Data.ProgressColor;
                    item.Data.Value = (int)(item.CompletePercentage() * 100d);
                    item.Data.CustomText = $"{txtProcessName.Text}({item.InitialWeight}): Wait({item.TotalWaitingTime}), P({item.Weight})";
                    //change color to show active process
                    item.Data.ProgressColor = (c == Color.OrangeRed) ? Color.LightGreen : Color.OrangeRed;

                    //Return it back to the previous color after quantom
                    new Thread(() =>
                    {
                        Thread.Sleep(_quantomTime);
                        item.Data.Invoke(() =>
                        {
                            item.Data.ProgressColor = c;
                        });
                    }).Start();
                });

                if (removed)
                {
                    ProcessesViewPanel.Invoke(() =>
                    {
                        _processEnded.Add(new Tuple<string, int, ulong>(item.Data.CustomText, item.InitialWeight, item.TotalWaitingTime));
                        Thread.Sleep(_quantomTime);
                        if (ProcessesViewPanel.Controls.Contains(item.Data))
                            ProcessesViewPanel.Controls.Remove(item.Data);
                    });

                    CalculateWSR();
                    SetCount();
                }
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

            ProcessesViewPanel.Width = percent * this.Width / 100;

            toolStriptxtPanelSize.TextBox.Text = $"{text}%";
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            toolStriptxtPanelSize_KeyDown(null, new KeyEventArgs(keyData: Keys.Enter));
        }

        private void btnAddProcess_Click(object sender, EventArgs e)
        {
            var time = (int)txtProcessTime.Value;
            var bar = new TextProgressBar()
            {
                Dock = DockStyle.Top,
                CustomText = $"{txtProcessName.Text}({time}):",
                Value = 0,
                VisualMode = ProgressBarDisplayMode.CustomText,
                Minimum = 0,
                Maximum = 100,
            };

            _processes.AddItem(bar, time);
            ProcessesViewPanel.Controls.Add(bar);

            SetCount();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _timerEnabled = !_timerEnabled;

            btnStart.Text = (_timerEnabled) ? "Stop" : "Start";
            txtQTime.Enabled = !_timerEnabled;

            if (_timerEnabled)
            {
                _timer = new Thread(Timer);
                _timer.IsBackground = true;
                _timer.Start();
            }
        }

        private void Timer()
        {
            while (_timerEnabled)
            {
                _processes.GetNext();
                Thread.Sleep(_quantomTime);
            }
        }

        private void txtQTime_ValueChanged(object sender, EventArgs e)
        {
            _quantomTime = (int)txtQTime.Value;
        }

        private void CalculateWSR()
        {
            new Thread(() =>
                panelStatus.Invoke(() => { 
                    var rTime = _processEnded.Sum(i => i.Item2);
                    var count = _processEnded.Count;
                    var wTime = _processEnded.Sum(p => (long)p.Item3);

                    var ast = (float)rTime / count;

                    var awt = (float)wTime / count;

                    var art = awt + ast;

                    lblCompletedProcesses.Text = count.ToString();
                    lblAWT.Text = awt.ToString("00.00 q");
                    lblAST.Text = ast.ToString("00.00 q");
                    lblART.Text = art.ToString("00.00 q");               
                })
            ).Start();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            SetCount();
        }
    }
}