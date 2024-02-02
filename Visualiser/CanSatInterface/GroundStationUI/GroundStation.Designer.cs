﻿namespace GroundStationUI
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
            grpLog = new GroupBox();
            btnClearLog = new Button();
            lstLog = new ListBox();
            grpLiveView = new GroupBox();
            tblLiveView = new TableLayoutPanel();
            label3 = new Label();
            lblAltitude = new Label();
            label2 = new Label();
            lblTemperature = new Label();
            label1 = new Label();
            lblPressure = new Label();
            tabControl1 = new TabControl();
            tabTemperature = new TabPage();
            tabBattery = new TabPage();
            label4 = new Label();
            lblBatteryVoltage = new Label();
            groupBox1.SuspendLayout();
            grpLog.SuspendLayout();
            grpLiveView.SuspendLayout();
            tblLiveView.SuspendLayout();
            tabControl1.SuspendLayout();
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
            // grpLog
            // 
            grpLog.Controls.Add(btnClearLog);
            grpLog.Controls.Add(lstLog);
            grpLog.Location = new Point(18, 375);
            grpLog.Name = "grpLog";
            grpLog.Size = new Size(770, 222);
            grpLog.TabIndex = 2;
            grpLog.TabStop = false;
            grpLog.Text = "Log:";
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
            // lstLog
            // 
            lstLog.FormattingEnabled = true;
            lstLog.ItemHeight = 15;
            lstLog.Location = new Point(6, 22);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(677, 184);
            lstLog.TabIndex = 0;
            // 
            // grpLiveView
            // 
            grpLiveView.Controls.Add(tblLiveView);
            grpLiveView.Location = new Point(805, 22);
            grpLiveView.Name = "grpLiveView";
            grpLiveView.Size = new Size(251, 341);
            grpLiveView.TabIndex = 3;
            grpLiveView.TabStop = false;
            grpLiveView.Text = "Live View:";
            // 
            // tblLiveView
            // 
            tblLiveView.ColumnCount = 2;
            tblLiveView.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblLiveView.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblLiveView.Controls.Add(label4, 0, 3);
            tblLiveView.Controls.Add(label3, 0, 2);
            tblLiveView.Controls.Add(label2, 0, 1);
            tblLiveView.Controls.Add(lblTemperature, 1, 0);
            tblLiveView.Controls.Add(label1, 0, 0);
            tblLiveView.Controls.Add(lblPressure, 1, 1);
            tblLiveView.Controls.Add(lblBatteryVoltage, 1, 3);
            tblLiveView.Controls.Add(lblAltitude, 1, 2);
            tblLiveView.Dock = DockStyle.Fill;
            tblLiveView.Location = new Point(3, 19);
            tblLiveView.Name = "tblLiveView";
            tblLiveView.RowCount = 4;
            tblLiveView.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblLiveView.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblLiveView.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblLiveView.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblLiveView.Size = new Size(245, 319);
            tblLiveView.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 278);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 5;
            label3.Text = "Altitude:";
            // 
            // lblAltitude
            // 
            lblAltitude.AutoSize = true;
            lblAltitude.Location = new Point(125, 278);
            lblAltitude.Name = "lblAltitude";
            lblAltitude.Size = new Size(45, 15);
            lblAltitude.TabIndex = 4;
            lblAltitude.Text = "Not set";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 139);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 3;
            label2.Text = "Pressure:";
            // 
            // lblTemperature
            // 
            lblTemperature.AutoSize = true;
            lblTemperature.Location = new Point(125, 0);
            lblTemperature.Name = "lblTemperature";
            lblTemperature.Size = new Size(45, 15);
            lblTemperature.TabIndex = 1;
            lblTemperature.Text = "Not set";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 0;
            label1.Text = "Temperature:";
            // 
            // lblPressure
            // 
            lblPressure.AutoSize = true;
            lblPressure.Location = new Point(125, 139);
            lblPressure.Name = "lblPressure";
            lblPressure.Size = new Size(45, 15);
            lblPressure.TabIndex = 2;
            lblPressure.Text = "Not set";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabTemperature);
            tabControl1.Controls.Add(tabBattery);
            tabControl1.Location = new Point(218, 22);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(584, 341);
            tabControl1.TabIndex = 4;
            // 
            // tabTemperature
            // 
            tabTemperature.Location = new Point(4, 24);
            tabTemperature.Name = "tabTemperature";
            tabTemperature.Padding = new Padding(3);
            tabTemperature.Size = new Size(576, 313);
            tabTemperature.TabIndex = 0;
            tabTemperature.Text = "Temperature";
            tabTemperature.UseVisualStyleBackColor = true;
            // 
            // tabBattery
            // 
            tabBattery.Location = new Point(4, 24);
            tabBattery.Name = "tabBattery";
            tabBattery.Padding = new Padding(3);
            tabBattery.Size = new Size(576, 313);
            tabBattery.TabIndex = 1;
            tabBattery.Text = "Battery";
            tabBattery.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 298);
            label4.Name = "label4";
            label4.Size = new Size(89, 15);
            label4.TabIndex = 6;
            label4.Text = "Battery Voltage:";
            // 
            // lblBatteryVoltage
            // 
            lblBatteryVoltage.AutoSize = true;
            lblBatteryVoltage.Location = new Point(125, 298);
            lblBatteryVoltage.Name = "lblBatteryVoltage";
            lblBatteryVoltage.Size = new Size(45, 15);
            lblBatteryVoltage.TabIndex = 7;
            lblBatteryVoltage.Text = "Not set";
            // 
            // GroundStation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 609);
            Controls.Add(tabControl1);
            Controls.Add(grpLiveView);
            Controls.Add(grpLog);
            Controls.Add(groupBox1);
            Name = "GroundStation";
            Text = "CanSat Ground Station";
            FormClosing += GroundStation_FormClosing;
            Load += GroundStation_Load;
            groupBox1.ResumeLayout(false);
            grpLog.ResumeLayout(false);
            grpLiveView.ResumeLayout(false);
            tblLiveView.ResumeLayout(false);
            tblLiveView.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnConnect;
        private Button btnRefresh;
        private ListBox lstDevices;
        private GroupBox grpLog;
        private Button btnClearLog;
        private ListBox lstLog;
        private GroupBox grpLiveView;
        private TableLayoutPanel tblLiveView;
        private Label lblTemperature;
        private Label label1;
        private Label label2;
        private Label lblPressure;
        private Label label3;
        private Label lblAltitude;
        private TabControl tabControl1;
        private TabPage tabTemperature;
        private TabPage tabBattery;
        private Label label4;
        private Label lblBatteryVoltage;
    }
}