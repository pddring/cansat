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
            groupDevices = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnRefresh = new Button();
            btnConnect = new Button();
            lstDevices = new ListBox();
            groupLog = new GroupBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnClearLog = new Button();
            btnExport = new Button();
            lstLog = new ListBox();
            groupLiveView = new GroupBox();
            tblLiveView = new TableLayoutPanel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            lblTemperature = new Label();
            label1 = new Label();
            lblPressure = new Label();
            lblBatteryVoltage = new Label();
            lblAltitude = new Label();
            lblAcceleration = new Label();
            lblMagneticField = new Label();
            label7 = new Label();
            label8 = new Label();
            lblGpsLock = new Label();
            lblRSSI = new Label();
            label10 = new Label();
            lblRemoteRecording = new Label();
            tabGraphs = new TabControl();
            tabTemperature = new TabPage();
            tabBattery = new TabPage();
            tabPressureAndAltityde = new TabPage();
            tabAcceleration = new TabPage();
            tabMagneticField = new TabPage();
            tabMap = new TabPage();
            btnOpenWeb = new Button();
            mainMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            devicesToolStripMenuItem = new ToolStripMenuItem();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            connectToolStripMenuItem = new ToolStripMenuItem();
            logToolStripMenuItem = new ToolStripMenuItem();
            clearToolStripMenuItem = new ToolStripMenuItem();
            liveViewToolStripMenuItem = new ToolStripMenuItem();
            graphsToolStripMenuItem = new ToolStripMenuItem();
            printDialog1 = new PrintDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            groupDevices.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupLog.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            groupLiveView.SuspendLayout();
            tblLiveView.SuspendLayout();
            tabGraphs.SuspendLayout();
            tabMap.SuspendLayout();
            mainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // groupDevices
            // 
            groupDevices.Controls.Add(flowLayoutPanel1);
            groupDevices.Controls.Add(lstDevices);
            groupDevices.Dock = DockStyle.Left;
            groupDevices.Location = new Point(0, 24);
            groupDevices.Name = "groupDevices";
            groupDevices.Size = new Size(200, 585);
            groupDevices.TabIndex = 0;
            groupDevices.TabStop = false;
            groupDevices.Text = "Devices:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(btnRefresh);
            flowLayoutPanel1.Controls.Add(btnConnect);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(3, 553);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(194, 29);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(3, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "&Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(84, 3);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "&Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // lstDevices
            // 
            lstDevices.Dock = DockStyle.Fill;
            lstDevices.FormattingEnabled = true;
            lstDevices.ItemHeight = 15;
            lstDevices.Location = new Point(3, 19);
            lstDevices.Name = "lstDevices";
            lstDevices.Size = new Size(194, 563);
            lstDevices.TabIndex = 0;
            // 
            // groupLog
            // 
            groupLog.Controls.Add(flowLayoutPanel2);
            groupLog.Controls.Add(lstLog);
            groupLog.Dock = DockStyle.Bottom;
            groupLog.Location = new Point(200, 387);
            groupLog.Name = "groupLog";
            groupLog.Size = new Size(868, 222);
            groupLog.TabIndex = 2;
            groupLog.TabStop = false;
            groupLog.Text = "Log:";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.Controls.Add(btnClearLog);
            flowLayoutPanel2.Controls.Add(btnExport);
            flowLayoutPanel2.Dock = DockStyle.Right;
            flowLayoutPanel2.Location = new Point(784, 19);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(81, 200);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // btnClearLog
            // 
            btnClearLog.Location = new Point(3, 3);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(75, 23);
            btnClearLog.TabIndex = 1;
            btnClearLog.Text = "C&lear";
            btnClearLog.UseVisualStyleBackColor = true;
            btnClearLog.Click += btnClearLog_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(3, 32);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(75, 23);
            btnExport.TabIndex = 2;
            btnExport.Text = "E&xport";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // lstLog
            // 
            lstLog.Dock = DockStyle.Fill;
            lstLog.FormattingEnabled = true;
            lstLog.ItemHeight = 15;
            lstLog.Location = new Point(3, 19);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(862, 200);
            lstLog.TabIndex = 0;
            // 
            // groupLiveView
            // 
            groupLiveView.Controls.Add(tblLiveView);
            groupLiveView.Dock = DockStyle.Right;
            groupLiveView.Location = new Point(751, 24);
            groupLiveView.Name = "groupLiveView";
            groupLiveView.Size = new Size(317, 363);
            groupLiveView.TabIndex = 3;
            groupLiveView.TabStop = false;
            groupLiveView.Text = "Live View:";
            // 
            // tblLiveView
            // 
            tblLiveView.ColumnCount = 2;
            tblLiveView.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.76206F));
            tblLiveView.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.2379456F));
            tblLiveView.Controls.Add(label6, 0, 5);
            tblLiveView.Controls.Add(label5, 0, 4);
            tblLiveView.Controls.Add(label4, 0, 3);
            tblLiveView.Controls.Add(label3, 0, 2);
            tblLiveView.Controls.Add(label2, 0, 1);
            tblLiveView.Controls.Add(lblTemperature, 1, 0);
            tblLiveView.Controls.Add(label1, 0, 0);
            tblLiveView.Controls.Add(lblPressure, 1, 1);
            tblLiveView.Controls.Add(lblBatteryVoltage, 1, 3);
            tblLiveView.Controls.Add(lblAltitude, 1, 2);
            tblLiveView.Controls.Add(lblAcceleration, 1, 4);
            tblLiveView.Controls.Add(lblMagneticField, 1, 5);
            tblLiveView.Controls.Add(label7, 0, 6);
            tblLiveView.Controls.Add(label8, 0, 7);
            tblLiveView.Controls.Add(lblGpsLock, 1, 6);
            tblLiveView.Controls.Add(lblRSSI, 1, 7);
            tblLiveView.Controls.Add(label10, 0, 9);
            tblLiveView.Controls.Add(lblRemoteRecording, 1, 9);
            tblLiveView.Dock = DockStyle.Fill;
            tblLiveView.Location = new Point(3, 19);
            tblLiveView.Name = "tblLiveView";
            tblLiveView.RowCount = 11;
            tblLiveView.RowStyles.Add(new RowStyle());
            tblLiveView.RowStyles.Add(new RowStyle());
            tblLiveView.RowStyles.Add(new RowStyle());
            tblLiveView.RowStyles.Add(new RowStyle());
            tblLiveView.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblLiveView.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblLiveView.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblLiveView.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblLiveView.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblLiveView.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblLiveView.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblLiveView.Size = new Size(311, 341);
            tblLiveView.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 80);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 10;
            label6.Text = "Magnetic Field:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 60);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 8;
            label5.Text = "Acceleration:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 45);
            label4.Name = "label4";
            label4.Size = new Size(89, 15);
            label4.TabIndex = 6;
            label4.Text = "Battery Voltage:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 30);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 5;
            label3.Text = "Altitude:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 15);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 3;
            label2.Text = "Pressure:";
            // 
            // lblTemperature
            // 
            lblTemperature.AutoSize = true;
            lblTemperature.Location = new Point(108, 0);
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
            lblPressure.Location = new Point(108, 15);
            lblPressure.Name = "lblPressure";
            lblPressure.Size = new Size(45, 15);
            lblPressure.TabIndex = 2;
            lblPressure.Text = "Not set";
            // 
            // lblBatteryVoltage
            // 
            lblBatteryVoltage.AutoSize = true;
            lblBatteryVoltage.Location = new Point(108, 45);
            lblBatteryVoltage.Name = "lblBatteryVoltage";
            lblBatteryVoltage.Size = new Size(45, 15);
            lblBatteryVoltage.TabIndex = 7;
            lblBatteryVoltage.Text = "Not set";
            // 
            // lblAltitude
            // 
            lblAltitude.AutoSize = true;
            lblAltitude.Location = new Point(108, 30);
            lblAltitude.Name = "lblAltitude";
            lblAltitude.Size = new Size(45, 15);
            lblAltitude.TabIndex = 4;
            lblAltitude.Text = "Not set";
            // 
            // lblAcceleration
            // 
            lblAcceleration.AutoSize = true;
            lblAcceleration.Location = new Point(108, 60);
            lblAcceleration.Name = "lblAcceleration";
            lblAcceleration.Size = new Size(45, 15);
            lblAcceleration.TabIndex = 9;
            lblAcceleration.Text = "Not set";
            // 
            // lblMagneticField
            // 
            lblMagneticField.AutoSize = true;
            lblMagneticField.Location = new Point(108, 80);
            lblMagneticField.Name = "lblMagneticField";
            lblMagneticField.Size = new Size(45, 15);
            lblMagneticField.TabIndex = 11;
            lblMagneticField.Text = "Not set";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 100);
            label7.Name = "label7";
            label7.Size = new Size(56, 15);
            label7.TabIndex = 12;
            label7.Text = "GPS Lock";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 120);
            label8.Name = "label8";
            label8.Size = new Size(32, 15);
            label8.TabIndex = 13;
            label8.Text = "RSSI ";
            // 
            // lblGpsLock
            // 
            lblGpsLock.AutoSize = true;
            lblGpsLock.Location = new Point(108, 100);
            lblGpsLock.Name = "lblGpsLock";
            lblGpsLock.Size = new Size(45, 15);
            lblGpsLock.TabIndex = 14;
            lblGpsLock.Text = "Not set";
            // 
            // lblRSSI
            // 
            lblRSSI.AutoSize = true;
            lblRSSI.Location = new Point(108, 120);
            lblRSSI.Name = "lblRSSI";
            lblRSSI.Size = new Size(45, 15);
            lblRSSI.TabIndex = 15;
            lblRSSI.Text = "Not set";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 160);
            label10.Name = "label10";
            label10.Size = new Size(14, 15);
            label10.TabIndex = 17;
            label10.Text = "R";
            // 
            // lblRemoteRecording
            // 
            lblRemoteRecording.AutoSize = true;
            lblRemoteRecording.Location = new Point(108, 160);
            lblRemoteRecording.Name = "lblRemoteRecording";
            lblRemoteRecording.Size = new Size(45, 15);
            lblRemoteRecording.TabIndex = 15;
            lblRemoteRecording.Text = "Not set";
            // 
            // tabGraphs
            // 
            tabGraphs.Controls.Add(tabTemperature);
            tabGraphs.Controls.Add(tabBattery);
            tabGraphs.Controls.Add(tabPressureAndAltityde);
            tabGraphs.Controls.Add(tabAcceleration);
            tabGraphs.Controls.Add(tabMagneticField);
            tabGraphs.Controls.Add(tabMap);
            tabGraphs.Dock = DockStyle.Fill;
            tabGraphs.Location = new Point(200, 24);
            tabGraphs.Name = "tabGraphs";
            tabGraphs.SelectedIndex = 0;
            tabGraphs.Size = new Size(551, 363);
            tabGraphs.TabIndex = 4;
            // 
            // tabTemperature
            // 
            tabTemperature.Location = new Point(4, 24);
            tabTemperature.Name = "tabTemperature";
            tabTemperature.Padding = new Padding(3);
            tabTemperature.Size = new Size(543, 335);
            tabTemperature.TabIndex = 0;
            tabTemperature.Text = "Temperature";
            tabTemperature.UseVisualStyleBackColor = true;
            // 
            // tabBattery
            // 
            tabBattery.Location = new Point(4, 24);
            tabBattery.Name = "tabBattery";
            tabBattery.Padding = new Padding(3);
            tabBattery.Size = new Size(543, 335);
            tabBattery.TabIndex = 1;
            tabBattery.Text = "Battery";
            tabBattery.UseVisualStyleBackColor = true;
            // 
            // tabPressureAndAltityde
            // 
            tabPressureAndAltityde.Location = new Point(4, 24);
            tabPressureAndAltityde.Name = "tabPressureAndAltityde";
            tabPressureAndAltityde.Padding = new Padding(3);
            tabPressureAndAltityde.Size = new Size(543, 335);
            tabPressureAndAltityde.TabIndex = 2;
            tabPressureAndAltityde.Text = "Pressure and altitude";
            tabPressureAndAltityde.UseVisualStyleBackColor = true;
            // 
            // tabAcceleration
            // 
            tabAcceleration.Location = new Point(4, 24);
            tabAcceleration.Name = "tabAcceleration";
            tabAcceleration.Padding = new Padding(3);
            tabAcceleration.Size = new Size(543, 335);
            tabAcceleration.TabIndex = 3;
            tabAcceleration.Text = "Acceleration";
            tabAcceleration.UseVisualStyleBackColor = true;
            // 
            // tabMagneticField
            // 
            tabMagneticField.Location = new Point(4, 24);
            tabMagneticField.Name = "tabMagneticField";
            tabMagneticField.Padding = new Padding(3);
            tabMagneticField.Size = new Size(543, 335);
            tabMagneticField.TabIndex = 4;
            tabMagneticField.Text = "Magnetic field";
            tabMagneticField.UseVisualStyleBackColor = true;
            // 
            // tabMap
            // 
            tabMap.Controls.Add(btnOpenWeb);
            tabMap.Location = new Point(4, 24);
            tabMap.Name = "tabMap";
            tabMap.Padding = new Padding(3);
            tabMap.Size = new Size(543, 335);
            tabMap.TabIndex = 5;
            tabMap.Text = "Map";
            tabMap.UseVisualStyleBackColor = true;
            // 
            // btnOpenWeb
            // 
            btnOpenWeb.Location = new Point(220, 156);
            btnOpenWeb.Name = "btnOpenWeb";
            btnOpenWeb.Size = new Size(169, 23);
            btnOpenWeb.TabIndex = 2;
            btnOpenWeb.Text = "Open Web Browser";
            btnOpenWeb.UseVisualStyleBackColor = true;
            btnOpenWeb.Click += btnOpenWeb_Click;
            // 
            // mainMenu
            // 
            mainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem });
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(1068, 24);
            mainMenu.TabIndex = 5;
            mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(93, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { devicesToolStripMenuItem, logToolStripMenuItem, liveViewToolStripMenuItem, graphsToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "&View";
            // 
            // devicesToolStripMenuItem
            // 
            devicesToolStripMenuItem.Checked = true;
            devicesToolStripMenuItem.CheckState = CheckState.Checked;
            devicesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { refreshToolStripMenuItem, connectToolStripMenuItem });
            devicesToolStripMenuItem.Name = "devicesToolStripMenuItem";
            devicesToolStripMenuItem.Size = new Size(122, 22);
            devicesToolStripMenuItem.Text = "&Devices";
            devicesToolStripMenuItem.Click += devicesToolStripMenuItem_Click;
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new Size(119, 22);
            refreshToolStripMenuItem.Text = "&Refresh";
            refreshToolStripMenuItem.Click += refreshToolStripMenuItem_Click;
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.Size = new Size(119, 22);
            connectToolStripMenuItem.Text = "&Connect";
            connectToolStripMenuItem.Click += connectToolStripMenuItem_Click;
            // 
            // logToolStripMenuItem
            // 
            logToolStripMenuItem.Checked = true;
            logToolStripMenuItem.CheckState = CheckState.Checked;
            logToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clearToolStripMenuItem });
            logToolStripMenuItem.Name = "logToolStripMenuItem";
            logToolStripMenuItem.Size = new Size(122, 22);
            logToolStripMenuItem.Text = "&Log";
            logToolStripMenuItem.Click += logToolStripMenuItem_Click;
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(101, 22);
            clearToolStripMenuItem.Text = "&Clear";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // liveViewToolStripMenuItem
            // 
            liveViewToolStripMenuItem.Checked = true;
            liveViewToolStripMenuItem.CheckState = CheckState.Checked;
            liveViewToolStripMenuItem.Name = "liveViewToolStripMenuItem";
            liveViewToolStripMenuItem.Size = new Size(122, 22);
            liveViewToolStripMenuItem.Text = "Li&ve view";
            liveViewToolStripMenuItem.Click += liveViewToolStripMenuItem_Click;
            // 
            // graphsToolStripMenuItem
            // 
            graphsToolStripMenuItem.Checked = true;
            graphsToolStripMenuItem.CheckState = CheckState.Checked;
            graphsToolStripMenuItem.Name = "graphsToolStripMenuItem";
            graphsToolStripMenuItem.Size = new Size(122, 22);
            graphsToolStripMenuItem.Text = "&Graphs";
            graphsToolStripMenuItem.Click += graphsToolStripMenuItem_Click;
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // GroundStation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 609);
            Controls.Add(tabGraphs);
            Controls.Add(groupLiveView);
            Controls.Add(groupLog);
            Controls.Add(groupDevices);
            Controls.Add(mainMenu);
            MainMenuStrip = mainMenu;
            Name = "GroundStation";
            Text = "CanSat Ground Station";
            FormClosing += GroundStation_FormClosing;
            Load += GroundStation_Load;
            groupDevices.ResumeLayout(false);
            groupDevices.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            groupLog.ResumeLayout(false);
            groupLog.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            groupLiveView.ResumeLayout(false);
            tblLiveView.ResumeLayout(false);
            tblLiveView.PerformLayout();
            tabGraphs.ResumeLayout(false);
            tabMap.ResumeLayout(false);
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupDevices;
        private Button btnConnect;
        private Button btnRefresh;
        private ListBox lstDevices;
        private GroupBox groupLog;
        private Button btnClearLog;
        private ListBox lstLog;
        private GroupBox groupLiveView;
        private TableLayoutPanel tblLiveView;
        private Label lblTemperature;
        private Label label1;
        private Label label2;
        private Label lblPressure;
        private Label label3;
        private Label lblAltitude;
        private TabControl tabGraphs;
        private TabPage tabTemperature;
        private TabPage tabBattery;
        private Label label4;
        private Label lblBatteryVoltage;
        private MenuStrip mainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem devicesToolStripMenuItem;
        private ToolStripMenuItem logToolStripMenuItem;
        private ToolStripMenuItem liveViewToolStripMenuItem;
        private ToolStripMenuItem graphsToolStripMenuItem;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private ToolStripMenuItem connectToolStripMenuItem;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private ToolStripMenuItem clearToolStripMenuItem;
        private Button btnExport;
        private TabPage tabPressureAndAltityde;
        private TabPage tabAcceleration;
        private Label label5;
        private Label lblAcceleration;
        private TabPage tabMagneticField;
        private Label label6;
        private Label lblMagneticField;
        private TabPage tabMap;
        private PrintDialog printDialog1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button btnOpenWeb;
        private Label label7;
        private Label label8;
        private Label lblGpsLock;
        private Label lblRSSI;
        private Label label10;
        private Label lblRemoteRecording;
    }
}