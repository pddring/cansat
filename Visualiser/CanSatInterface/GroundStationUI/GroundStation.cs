using OpenTK.Graphics.OpenGL4;
using ScottPlot;
using ScottPlot.Panels;
using ScottPlot.Plottables;
using System.IO.Ports;
using System.Net;
using System.Text;

namespace GroundStationUI
{
    public partial class GroundStation : Form
    {
        bool connected = false;

        private void SendGPSLocation(CanSatInterface.GPSCoordinates gps)
        {
            using (WebClient client = new WebClient())
            {
                var p = new System.Collections.Specialized.NameValueCollection();
                p.Add("cmd", "SET_LOCATION");
                p.Add("key", "__C4nSaT__");
                p.Add("lat", gps.Latitude.ToString());
                p.Add("lng", gps.Longitude.ToString());

                /// TODO: async request should fix it
                //byte[] responsebytes = client.UploadValues("https://tools.withcode.uk/cansat/api.php", "POST", p);
                //string responsebody = Encoding.UTF8.GetString(responsebytes);
            }

        }

        const string SIMULATED_DEVICE_NAME = "Simulated CanSat test device";
        CanSatInterface.CanSatInterface device;
        public GroundStation()
        {
            InitializeComponent();
        }

        public void UpdateDeviceList()
        {
            string[] portNames = SerialPort.GetPortNames();
            lstDevices.Items.Clear();
            foreach (string deviceName in portNames)
            {
                lstDevices.Items.Add(deviceName);
            }
            lstDevices.Items.Add(SIMULATED_DEVICE_NAME);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateDeviceList();
        }
        ScottPlot.WinForms.FormsPlot tempPlot;
        ScottPlot.WinForms.FormsPlot batteryPlot;
        ScottPlot.WinForms.FormsPlot pressureAndAltitudePlot;
        ScottPlot.WinForms.FormsPlot accelerationPlot;
        ScottPlot.WinForms.FormsPlot magneticFieldPlot;


        DataLogger tempLogger;
        DataLogger altitudeLogger;
        DataLogger pressureLogger;
        DataLogger batteryVoltageLogger;
        DataLogger accelerationXLogger;
        DataLogger accelerationYLogger;
        DataLogger accelerationZLogger;
        DataLogger magneticFieldXLogger;
        DataLogger magneticFieldYLogger;
        DataLogger magneticFieldZLogger;

        private void GroundStation_Load(object sender, EventArgs e)
        {

            // temperature graph
            tempPlot = new ScottPlot.WinForms.FormsPlot();
            tabTemperature.Controls.Add(tempPlot);
            tempPlot.Dock = DockStyle.Fill;
            tempLogger = tempPlot.Plot.Add.DataLogger();
            tempPlot.Plot.Axes.Left.Label.Text = "Temperature ('C)";
            tempPlot.Plot.Axes.Left.Label.ForeColor = tempLogger.Color;
            tempPlot.Plot.Axes.Bottom.Label.Text = "Time (s)";

            // pressure and altitude graph
            pressureAndAltitudePlot = new ScottPlot.WinForms.FormsPlot();
            tabPressureAndAltityde.Controls.Add(pressureAndAltitudePlot);
            pressureAndAltitudePlot.Dock = DockStyle.Fill;
            altitudeLogger = pressureAndAltitudePlot.Plot.Add.DataLogger();
            altitudeLogger.Axes.YAxis = pressureAndAltitudePlot.Plot.Axes.Right;
            pressureAndAltitudePlot.Plot.Axes.Right.Label.Text = "Altitude (m)";
            pressureAndAltitudePlot.Plot.Axes.Right.Label.ForeColor = altitudeLogger.Color;
            pressureAndAltitudePlot.Plot.Axes.Bottom.Label.Text = "Time (s)";

            pressureLogger = pressureAndAltitudePlot.Plot.Add.DataLogger();
            pressureLogger.Axes.YAxis = pressureAndAltitudePlot.Plot.Axes.Left;
            pressureAndAltitudePlot.Plot.Axes.Left.Label.Text = "Pressure (hPa)";
            pressureAndAltitudePlot.Plot.Axes.Left.Label.ForeColor = pressureLogger.Color;

            // acceleration graph
            accelerationPlot = new ScottPlot.WinForms.FormsPlot();
            tabAcceleration.Controls.Add(accelerationPlot);
            accelerationPlot.Dock = DockStyle.Fill;
            accelerationXLogger = accelerationPlot.Plot.Add.DataLogger();
            accelerationYLogger = accelerationPlot.Plot.Add.DataLogger();
            accelerationZLogger = accelerationPlot.Plot.Add.DataLogger();
            accelerationPlot.Plot.Axes.Bottom.Label.Text = "Time (s)";
            accelerationPlot.Plot.Axes.Left.Label.Text = ("Acceleration (m/s²)");

            // acceleration plot labels
            LegendItem xLeg = new()
            {
                LineColor = Colors.Blue,
                MarkerColor = Colors.Blue,
                LineWidth = 2,
                Label = "X Direction"
            };
            LegendItem yLeg = new()
            {
                LineColor = Colors.Orange,
                MarkerColor = Colors.Orange,
                LineWidth = 2,
                Label = "Y Direction"
            };
            LegendItem zLeg = new()
            {
                LineColor = Colors.Green,
                MarkerColor = Colors.Green,
                LineWidth = 2,
                Label = "Z Direction"
            };
            LegendItem[] items = { xLeg, yLeg, zLeg };
            accelerationPlot.Plot.ShowLegend(items);

            // magnetic field graph
            magneticFieldPlot = new ScottPlot.WinForms.FormsPlot();
            tabMagneticField.Controls.Add(magneticFieldPlot);
            magneticFieldPlot.Dock = DockStyle.Fill;
            magneticFieldXLogger = magneticFieldPlot.Plot.Add.DataLogger();
            magneticFieldYLogger = magneticFieldPlot.Plot.Add.DataLogger();
            magneticFieldZLogger = magneticFieldPlot.Plot.Add.DataLogger();
            magneticFieldPlot.Plot.Axes.Bottom.Label.Text = "Time (s)";
            magneticFieldPlot.Plot.Axes.Left.Label.Text = ("Magnetic Field Strength (µT)");

            LegendItem[] magLegends = {
                new LegendItem() {
                    Label = "X Direction",
                    LineColor = magneticFieldXLogger.Color
                },
                new LegendItem()
                {
                    Label = "Y Direction",
                    LineColor = magneticFieldYLogger.Color
                },
                new LegendItem() {
                    Label = "Z Direction",
                    LineColor = magneticFieldZLogger.Color
                }
            };
            magneticFieldPlot.Plot.ShowLegend(magLegends);

            // battery graph
            batteryPlot = new ScottPlot.WinForms.FormsPlot();
            tabBattery.Controls.Add(batteryPlot);
            batteryPlot.Dock = DockStyle.Fill;
            batteryVoltageLogger = batteryPlot.Plot.Add.DataLogger();
            batteryPlot.Plot.Axes.Left.Label.Text = "Voltage (v)";
            batteryPlot.Plot.Axes.Left.Label.ForeColor = batteryVoltageLogger.Color;
            batteryPlot.Plot.Axes.Bottom.Label.Text = "Time (s)";

            UpdateDeviceList();
        }

        void Connect()
        {
            if (connected)
            {
                connected = false;
                btnConnect.Text = "&Connect";
                if (lstDevices.SelectedItem != null)
                {
                    device.Disconnect();
                }
            }
            else
            {
                connected = true;

                if (lstDevices.SelectedItem != null)
                {
                    btnConnect.Text = "Dis&connect";
                    string deviceName = lstDevices.SelectedItem.ToString();

                    if (deviceName == SIMULATED_DEVICE_NAME)
                    {
                        device = new CanSatInterface.CanSatSimulatedTest(deviceName);
                    }
                    else
                    {
                        device = new CanSatInterface.CanSat(deviceName);
                    }
                    device.Connect((string data, CanSatInterface.CanSat.DataLabel lastUpdated) =>
                    {
                        double[] a = new double[3];
                        CanSatInterface.GPSCoordinates gps = new CanSatInterface.GPSCoordinates();
                        
                        lstLog.Invoke((Delegate)(() =>
                        {
                            try
                            {
                                lstLog.Items.Add(data);
                                double time = device.getRunningTime();
                                switch (lastUpdated)
                                {
                                    case CanSatInterface.CanSatInterface.DataLabel.GPSLatitude:
                                        gps = device.getGPSLocation();
                                        SendGPSLocation(gps);
                                        break;
                                    case CanSatInterface.CanSatInterface.DataLabel.GPSLongitude:
                                        gps = device.getGPSLocation();
                                        SendGPSLocation(gps);
                                        break;

                                    case CanSatInterface.CanSatInterface.DataLabel.AccelerationX:
                                        a = device.getAcceleration();
                                        accelerationXLogger.Add(time, a[0]);
                                        lblAcceleration.Text = $"{a[0]:f2}, {a[1]:f2}, {a[2]:f2} m/s²";
                                        accelerationPlot.Refresh();
                                        break;

                                    case CanSatInterface.CanSatInterface.DataLabel.AccelerationY:
                                        a = device.getAcceleration();
                                        accelerationYLogger.Add(time, a[1]);
                                        lblAcceleration.Text = $"{a[0]:f2}, {a[1]:f2}, {a[2]:f2} m/s²";
                                        accelerationPlot.Refresh();
                                        break;

                                    case CanSatInterface.CanSatInterface.DataLabel.AccelerationZ:
                                        a = device.getAcceleration();
                                        accelerationZLogger.Add(time, a[2]);
                                        lblAcceleration.Text = $"{a[0]:f2}, {a[1]:f2}, {a[2]:f2} m/s²";
                                        accelerationPlot.Refresh();
                                        break;

                                    case CanSatInterface.CanSatInterface.DataLabel.MagneticFieldStrengthX:
                                        a = device.getMagneticFieldStrength();
                                        magneticFieldXLogger.Add(time, a[0]);
                                        lblMagneticField.Text = $"{a[0]:f2}, {a[1]:f2}, {a[2]:f2} µT";
                                        magneticFieldPlot.Refresh();
                                        break;

                                    case CanSatInterface.CanSatInterface.DataLabel.MagneticFieldStrengthY:
                                        a = device.getMagneticFieldStrength();
                                        magneticFieldYLogger.Add(time, a[1]);
                                        lblMagneticField.Text = $"{a[0]:f2}, {a[1]:f2}, {a[2]:f2} µT";
                                        magneticFieldPlot.Refresh();
                                        break;

                                    case CanSatInterface.CanSatInterface.DataLabel.MagneticFieldStrengthZ:
                                        a = device.getMagneticFieldStrength();
                                        magneticFieldZLogger.Add(time, a[2]);
                                        lblMagneticField.Text = $"{a[0]:f2}, {a[1]:f2}, {a[2]:f2} µT";
                                        magneticFieldPlot.Refresh();
                                        break;

                                    case CanSatInterface.CanSatInterface.DataLabel.Temperature:
                                        double temperature = device.getTemperature();
                                        lblTemperature.Text = $"{temperature}'C";
                                        tempLogger.Add(time, temperature);
                                        tempPlot.Refresh();
                                        break;

                                    case CanSatInterface.CanSatInterface.DataLabel.Altitude:
                                        double altitude = device.getAltitude();
                                        lblAltitude.Text = $"{altitude:f2}m";
                                        altitudeLogger.Add(time, altitude);
                                        pressureAndAltitudePlot.Refresh();
                                        break;

                                    case CanSatInterface.CanSatInterface.DataLabel.Pressure:
                                        double pressure = device.getPressure();
                                        lblPressure.Text = $"{pressure:f2}hPa";
                                        pressureLogger.Add(time, pressure);
                                        pressureAndAltitudePlot.Refresh();
                                        break;

                                    case CanSatInterface.CanSatInterface.DataLabel.BatteryVoltage:
                                        double voltage = device.getBatteryVoltage();
                                        lblBatteryVoltage.Text = $"{voltage:f2}v";
                                        batteryVoltageLogger.Add(time, voltage);
                                        batteryPlot.Refresh();
                                        break;
                                }
                                lstLog.SelectedIndex = lstLog.Items.Count - 1;

                            }
                            catch (Exception e)
                            {
                                lstLog.Items.Add("Error: " + e.Message);
                            }
                        }));

                        
                    });
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            ClearLog();
        }

        private void GroundStation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connected)
            {
                device.Disconnect();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void devicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            devicesToolStripMenuItem.Checked = !devicesToolStripMenuItem.Checked;
            groupDevices.Visible = devicesToolStripMenuItem.Checked;
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logToolStripMenuItem.Checked = !logToolStripMenuItem.Checked;
            groupDevices.Visible = logToolStripMenuItem.Checked;
        }

        private void liveViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            liveViewToolStripMenuItem.Checked = !liveViewToolStripMenuItem.Checked;
            groupLiveView.Visible = liveViewToolStripMenuItem.Checked;
        }

        private void graphsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphsToolStripMenuItem.Checked = !graphsToolStripMenuItem.Checked;
            tabGraphs.Visible = graphsToolStripMenuItem.Checked;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDeviceList();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connect();
        }

        void ClearLog()
        {
            lstLog.Items.Clear();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearLog();
        }

        void ExportLog(string Filename)
        {
            using (StreamWriter s = new StreamWriter(Filename))
            {
                foreach (var item in lstLog.Items)
                {
                    s.WriteLine(item.ToString());
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Export log file";
            dlg.Filter = "Text file|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ExportLog(dlg.FileName);
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void btnOpenWeb_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", "https://tools.withcode.uk/cansat");
        }

    }
}