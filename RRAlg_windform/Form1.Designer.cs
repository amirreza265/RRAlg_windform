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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ProcessesPanel = new System.Windows.Forms.Panel();
            this.ProcessesListView = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStriptxtPanelSize = new System.Windows.Forms.ToolStripTextBox();
            this.stLblCount = new System.Windows.Forms.ToolStripLabel();
            this.pbarTotal = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sleepProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.txtProcessTime = new System.Windows.Forms.NumericUpDown();
            this.btnAddProcess = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtQTime = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.lblART = new System.Windows.Forms.Label();
            this.lblARTTitle = new System.Windows.Forms.Label();
            this.lblAST = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAWT = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCompletedProcesses = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ProcessesPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQTime)).BeginInit();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProcessesPanel
            // 
            this.ProcessesPanel.AutoScroll = true;
            this.ProcessesPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ProcessesPanel.Controls.Add(this.ProcessesListView);
            this.ProcessesPanel.Controls.Add(this.toolStrip1);
            this.ProcessesPanel.Controls.Add(this.menuStrip1);
            this.ProcessesPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProcessesPanel.Location = new System.Drawing.Point(0, 0);
            this.ProcessesPanel.Name = "ProcessesPanel";
            this.ProcessesPanel.Size = new System.Drawing.Size(736, 622);
            this.ProcessesPanel.TabIndex = 0;
            // 
            // ProcessesListView
            // 
            this.ProcessesListView.AutoScroll = true;
            this.ProcessesListView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ProcessesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessesListView.Location = new System.Drawing.Point(0, 28);
            this.ProcessesListView.Name = "ProcessesListView";
            this.ProcessesListView.Size = new System.Drawing.Size(732, 563);
            this.ProcessesListView.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStriptxtPanelSize,
            this.stLblCount,
            this.pbarTotal});
            this.toolStrip1.Location = new System.Drawing.Point(0, 591);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(732, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStriptxtPanelSize
            // 
            this.toolStriptxtPanelSize.Name = "toolStriptxtPanelSize";
            this.toolStriptxtPanelSize.Size = new System.Drawing.Size(60, 27);
            this.toolStriptxtPanelSize.Text = "70%";
            this.toolStriptxtPanelSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStriptxtPanelSize_KeyDown);
            // 
            // stLblCount
            // 
            this.stLblCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stLblCount.Name = "stLblCount";
            this.stLblCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.stLblCount.Size = new System.Drawing.Size(48, 24);
            this.stLblCount.Text = "Count";
            this.stLblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbarTotal
            // 
            this.pbarTotal.Name = "pbarTotal";
            this.pbarTotal.Size = new System.Drawing.Size(300, 24);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(732, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeProcessToolStripMenuItem,
            this.sleepProcessToolStripMenuItem});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.colorToolStripMenuItem.Text = "Color";
            // 
            // activeProcessToolStripMenuItem
            // 
            this.activeProcessToolStripMenuItem.Name = "activeProcessToolStripMenuItem";
            this.activeProcessToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.activeProcessToolStripMenuItem.Text = "Active Process";
            this.activeProcessToolStripMenuItem.Click += new System.EventHandler(this.activeProcessToolStripMenuItem_Click);
            // 
            // sleepProcessToolStripMenuItem
            // 
            this.sleepProcessToolStripMenuItem.Name = "sleepProcessToolStripMenuItem";
            this.sleepProcessToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.sleepProcessToolStripMenuItem.Text = "Sleep Process";
            this.sleepProcessToolStripMenuItem.Click += new System.EventHandler(this.sleepProcessToolStripMenuItem_Click);
            // 
            // txtProcessName
            // 
            this.txtProcessName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtProcessName.Location = new System.Drawing.Point(736, 0);
            this.txtProcessName.Margin = new System.Windows.Forms.Padding(10);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.PlaceholderText = "Process name";
            this.txtProcessName.Size = new System.Drawing.Size(210, 27);
            this.txtProcessName.TabIndex = 1;
            this.txtProcessName.TextChanged += new System.EventHandler(this.txtProcessName_TextChanged);
            // 
            // txtProcessTime
            // 
            this.txtProcessTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtProcessTime.Location = new System.Drawing.Point(736, 27);
            this.txtProcessTime.Margin = new System.Windows.Forms.Padding(10);
            this.txtProcessTime.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtProcessTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtProcessTime.Name = "txtProcessTime";
            this.txtProcessTime.Size = new System.Drawing.Size(210, 27);
            this.txtProcessTime.TabIndex = 2;
            this.txtProcessTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddProcess
            // 
            this.btnAddProcess.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddProcess.Location = new System.Drawing.Point(736, 54);
            this.btnAddProcess.Name = "btnAddProcess";
            this.btnAddProcess.Size = new System.Drawing.Size(210, 29);
            this.btnAddProcess.TabIndex = 3;
            this.btnAddProcess.Text = "Add";
            this.btnAddProcess.UseVisualStyleBackColor = true;
            this.btnAddProcess.Click += new System.EventHandler(this.btnAddProcess_Click);
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnStart.Location = new System.Drawing.Point(736, 593);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(210, 29);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtQTime
            // 
            this.txtQTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtQTime.Location = new System.Drawing.Point(736, 566);
            this.txtQTime.Margin = new System.Windows.Forms.Padding(10);
            this.txtQTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtQTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQTime.Name = "txtQTime";
            this.txtQTime.Size = new System.Drawing.Size(210, 27);
            this.txtQTime.TabIndex = 5;
            this.txtQTime.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtQTime.ValueChanged += new System.EventHandler(this.txtQTime_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(736, 546);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Quantom Time :";
            // 
            // panelStatus
            // 
            this.panelStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelStatus.Controls.Add(this.lblART);
            this.panelStatus.Controls.Add(this.lblARTTitle);
            this.panelStatus.Controls.Add(this.lblAST);
            this.panelStatus.Controls.Add(this.label7);
            this.panelStatus.Controls.Add(this.lblAWT);
            this.panelStatus.Controls.Add(this.label4);
            this.panelStatus.Controls.Add(this.lblCompletedProcesses);
            this.panelStatus.Controls.Add(this.label2);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStatus.Location = new System.Drawing.Point(736, 83);
            this.panelStatus.Margin = new System.Windows.Forms.Padding(5);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Padding = new System.Windows.Forms.Padding(5);
            this.panelStatus.Size = new System.Drawing.Size(210, 176);
            this.panelStatus.TabIndex = 7;
            // 
            // lblART
            // 
            this.lblART.AutoSize = true;
            this.lblART.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblART.Location = new System.Drawing.Point(5, 145);
            this.lblART.Name = "lblART";
            this.lblART.Size = new System.Drawing.Size(60, 20);
            this.lblART.TabIndex = 7;
            this.lblART.Text = "amount";
            // 
            // lblARTTitle
            // 
            this.lblARTTitle.AutoSize = true;
            this.lblARTTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblARTTitle.Location = new System.Drawing.Point(5, 125);
            this.lblARTTitle.Name = "lblARTTitle";
            this.lblARTTitle.Size = new System.Drawing.Size(38, 20);
            this.lblARTTitle.TabIndex = 6;
            this.lblARTTitle.Text = "ART:";
            // 
            // lblAST
            // 
            this.lblAST.AutoSize = true;
            this.lblAST.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAST.Location = new System.Drawing.Point(5, 105);
            this.lblAST.Name = "lblAST";
            this.lblAST.Size = new System.Drawing.Size(60, 20);
            this.lblAST.TabIndex = 5;
            this.lblAST.Text = "amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(5, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "AST:";
            // 
            // lblAWT
            // 
            this.lblAWT.AutoSize = true;
            this.lblAWT.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAWT.Location = new System.Drawing.Point(5, 65);
            this.lblAWT.Name = "lblAWT";
            this.lblAWT.Size = new System.Drawing.Size(60, 20);
            this.lblAWT.TabIndex = 3;
            this.lblAWT.Text = "amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(5, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "AWT:";
            // 
            // lblCompletedProcesses
            // 
            this.lblCompletedProcesses.AutoSize = true;
            this.lblCompletedProcesses.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCompletedProcesses.Location = new System.Drawing.Point(5, 25);
            this.lblCompletedProcesses.Name = "lblCompletedProcesses";
            this.lblCompletedProcesses.Size = new System.Drawing.Size(48, 20);
            this.lblCompletedProcesses.TabIndex = 1;
            this.lblCompletedProcesses.Text = "Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(5, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Completed Processes:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 622);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQTime);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnAddProcess);
            this.Controls.Add(this.txtProcessTime);
            this.Controls.Add(this.txtProcessName);
            this.Controls.Add(this.ProcessesPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "RoundRobin";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ProcessesPanel.ResumeLayout(false);
            this.ProcessesPanel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQTime)).EndInit();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel ProcessesPanel;
        private TextBox txtProcessName;
        private NumericUpDown txtProcessTime;
        private Button btnAddProcess;
        private ToolStrip toolStrip1;
        private ToolStripTextBox toolStriptxtPanelSize;
        private Button btnStart;
        private NumericUpDown txtQTime;
        private Label label1;
        private Panel panelStatus;
        private Label lblCompletedProcesses;
        private Label label2;
        private Label lblART;
        private Label lblARTTitle;
        private Label lblAST;
        private Label label7;
        private Label lblAWT;
        private Label label4;
        private ToolStripLabel stLblCount;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem colorToolStripMenuItem;
        private ToolStripMenuItem activeProcessToolStripMenuItem;
        private ToolStripMenuItem sleepProcessToolStripMenuItem;
        private Panel ProcessesListView;
        private ToolStripProgressBar pbarTotal;
    }
}