using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RRAlg_windform
{
    public partial class ChartForm : Form
    {
        private Form1 _mainForm;
        private int _quantom;

        private double[] lastPointX;
        private double[] lastPointY;

        public ChartForm(Form1 mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _quantom = 1;

            lastPointX = new double[2];
            lastPointY = new double[2];

            formsPlot1.Plot.AxisScaleLock(true, EqualScaleMode.PreserveLargest);
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            formsPlot1.Plot.XLabel("q");
            formsPlot1.Plot.YLabel("AWT");

            Action<double, double> method = (awt, q) =>
            {
                AddPoint(q, awt);

                _mainForm.Reset();
                _mainForm.FillFromBackup();

                _mainForm.Quantom = ++_quantom;

                if (!_mainForm.TimerEnabled)
                {
                    _mainForm.StartOrStop();
                }
            };

            Action getNext = () =>
            {
                statusStrip1.Invoke(() =>
                {
                    pbar.Value = _mainForm.TotalPBar;
                });
            };

            _mainForm.OnFinish  += method;
            _mainForm.OnGetNext += getNext;

            this.FormClosed += (s, e) =>
            {
                if (_mainForm.TimerEnabled)
                    _mainForm.StartOrStop();

                _mainForm.OnFinish -= method;
            };
        }

        public void AddPoint(double x, double y)
        {
            lastPointX[1] = x;
            lastPointY[1] = y;

            formsPlot1.Plot.AddLine(lastPointX[0], lastPointY[0], lastPointX[1], lastPointY[1], Color.Green);
            formsPlot1.Plot.AddPoint(x, y, Color.Blue, 5, MarkerShape.filledSquare);
            formsPlot1.Plot.AddText(y.ToString("0.00"), x, y + 1);

            lastPointX[0] = x;
            lastPointY[0] = y;

            formsPlot1.Invoke(() =>
            {
                formsPlot1.Refresh();
            });
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var enable = _mainForm.StartOrStop();

            startToolStripMenuItem.Text = (enable) ? "Stop" : "Start";
        }


    }
}
