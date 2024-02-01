namespace GroundStationUI
{
    partial class GroundStation
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
            groupBox1 = new GroupBox();
            btnConnect = new Button();
            btnRefresh = new Button();
            lstDevices = new ListBox();
            grpTempPlot = new GroupBox();
            grpLog = new GroupBox();
            lstLog = new ListBox();
            btnClearLog = new Button();
            groupBox1.SuspendLayout();
            grpLog.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnConnect);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(lstDevices);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 357);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Devices:";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(81, 328);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "&Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(0, 328);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "&Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lstDevices
            // 
            lstDevices.FormattingEnabled = true;
            lstDevices.ItemHeight = 15;
            lstDevices.Location = new Point(6, 22);
            lstDevices.Name = "lstDevices";
            lstDevices.Size = new Size(188, 289);
            lstDevices.TabIndex = 0;
            // 
            // grpTempPlot
            // 
            grpTempPlot.Location = new Point(218, 12);
            grpTempPlot.Name = "grpTempPlot";
            grpTempPlot.Size = new Size(570, 351);
            grpTempPlot.TabIndex = 1;
            grpTempPlot.TabStop = false;
            grpTempPlot.Text = "Temperature";
            // 
            // grpLog
            // 
            grpLog.Controls.Add(btnClearLog);
            grpLog.Controls.Add(lstLog);
            grpLog.Location = new Point(18, 375);
            grpLog.Name = "grpLog";
            grpLog.Size = new Size(770, 222);
            grpLog.TabIndex = 2;
            grpLog.TabStop = false;
            grpLog.Text = "Log";
            // 
            // lstLog
            // 
            lstLog.FormattingEnabled = true;
            lstLog.ItemHeight = 15;
            lstLog.Location = new Point(6, 22);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(677, 184);
            lstLog.TabIndex = 0;
            // 
            // btnClearLog
            // 
            btnClearLog.Location = new Point(689, 22);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(75, 23);
            btnClearLog.TabIndex = 1;
            btnClearLog.Text = "C&lear";
            btnClearLog.UseVisualStyleBackColor = true;
            btnClearLog.Click += btnClearLog_Click;
            // 
            // GroundStation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 609);
            Controls.Add(grpLog);
            Controls.Add(grpTempPlot);
            Controls.Add(groupBox1);
            Name = "GroundStation";
            Text = "CanSat Ground Station";
            Load += GroundStation_Load;
            groupBox1.ResumeLayout(false);
            grpLog.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnConnect;
        private Button btnRefresh;
        private ListBox lstDevices;
        private GroupBox grpTempPlot;
        private GroupBox grpLog;
        private Button btnClearLog;
        private ListBox lstLog;
    }
}