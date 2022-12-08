namespace RRAlg_windform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ProcessesView = new System.Windows.Forms.Panel();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.txtProcessTime = new System.Windows.Forms.NumericUpDown();
            this.btnAddProcess = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessTime)).BeginInit();
            this.SuspendLayout();
            // 
            // ProcessesView
            // 
            this.ProcessesView.AutoScroll = true;
            this.ProcessesView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ProcessesView.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProcessesView.Location = new System.Drawing.Point(0, 0);
            this.ProcessesView.Name = "ProcessesView";
            this.ProcessesView.Size = new System.Drawing.Size(560, 515);
            this.ProcessesView.TabIndex = 0;
            // 
            // txtProcessName
            // 
            this.txtProcessName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtProcessName.Location = new System.Drawing.Point(560, 0);
            this.txtProcessName.Margin = new System.Windows.Forms.Padding(10);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.PlaceholderText = "Process name";
            this.txtProcessName.Size = new System.Drawing.Size(255, 27);
            this.txtProcessName.TabIndex = 1;
            // 
            // txtProcessTime
            // 
            this.txtProcessTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtProcessTime.Location = new System.Drawing.Point(560, 27);
            this.txtProcessTime.Margin = new System.Windows.Forms.Padding(10);
            this.txtProcessTime.Name = "txtProcessTime";
            this.txtProcessTime.Size = new System.Drawing.Size(255, 27);
            this.txtProcessTime.TabIndex = 2;
            // 
            // btnAddProcess
            // 
            this.btnAddProcess.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddProcess.Location = new System.Drawing.Point(560, 54);
            this.btnAddProcess.Name = "btnAddProcess";
            this.btnAddProcess.Size = new System.Drawing.Size(255, 29);
            this.btnAddProcess.TabIndex = 3;
            this.btnAddProcess.Text = "Add";
            this.btnAddProcess.UseVisualStyleBackColor = true;
            // 
            // timer
            // 
            this.timer.Interval = 300;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 515);
            this.Controls.Add(this.btnAddProcess);
            this.Controls.Add(this.txtProcessTime);
            this.Controls.Add(this.txtProcessName);
            this.Controls.Add(this.ProcessesView);
            this.Name = "Form1";
            this.Text = "RoundRobin";
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel ProcessesView;
        private TextBox txtProcessName;
        private NumericUpDown txtProcessTime;
        private Button btnAddProcess;
        private System.Windows.Forms.Timer timer;
    }
}