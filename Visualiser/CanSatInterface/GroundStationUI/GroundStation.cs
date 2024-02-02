using ScottPlot.Panels;
using ScottPlot.Plottables;
using System.IO.Ports;

namespace GroundStationUI
{
    public partial class GroundStation : Form
    {
        bool connected = false;
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
        DataLogger tempLogger;
        DataLogger altitudeLogger;
        DataLogger batteryVoltageLogger;

        private void GroundStation_Load(object sender, EventArgs e)
        {
            tempPlot = new ScottPlot.WinForms.FormsPlot();
            tabTemperature.Controls.Add(tempPlot);
            tempPlot.Dock = DockStyle.Fill;
            tempLogger = tempPlot.Plot.Add.DataLogger();
            altitudeLogger = tempPlot.Plot.Add.DataLogger();
            tempLogger.Axes.YAxis = tempPlot.Plot.Axes.Left;
            tempPlot.Plot.Axes.Left.Label.Text = "Temperature ('C)";
            tempPlot.Plot.Axes.Left.Label.ForeColor = tempLogger.Color;
            altitudeLogger.Axes.YAxis = tempPlot.Plot.Axes.Right;
            tempPlot.Plot.Axes.Right.Label.Text = "Altitude (m)";
            tempPlot.Plot.Axes.Right.Label.ForeColor = altitudeLogger.Color;
            tempPlot.Plot.Axes.Bottom.Label.Text = "Time (s)";

            batteryPlot = new ScottPlot.WinForms.FormsPlot();
            tabBattery.Controls.Add(batteryPlot);
            batteryPlot.Dock = DockStyle.Fill;
            batteryVoltageLogger = batteryPlot.Plot.Add.DataLogger();
            batteryPlot.Plot.Axes.Left.Label.Text = "Voltage (v)";
            batteryPlot.Plot.Axes.Left.Label.ForeColor = batteryVoltageLogger.Color;
            batteryPlot.Plot.Axes.Bottom.Label.Text = "Time (s)";

            UpdateDeviceList();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                connected = false;
                btnConnect.Text = "&Connect";
                device.Disconnect();
            }
            else
            {
                connected = true;
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
                    try
                    {
                        lstLog.Invoke(() =>
                        {
                            lstLog.Items.Add(data);
                            double time = device.getRunningTime();
                            switch (lastUpdated)
                            {
                                case CanSatInterface.CanSatInterface.DataLabel.Temperature:
                                    double temperature = device.getTemperature();
                                    lblTemperature.Text = $"{temperature}'C";
                                    tempLogger.Add(time, temperature);
                                    lblPressure.Text = $"{device.getPressure():f2}hPa";
                                    tempPlot.Refresh();
                                    break;

                                case CanSatInterface.CanSatInterface.DataLabel.Altitude:
                                    double altitude = device.getAltitude();
                                    lblAltitude.Text = $"{altitude:f2}m";
                                    altitudeLogger.Add(time, altitude);
                                    tempPlot.Refresh();
                                    break;

                                case CanSatInterface.CanSatInterface.DataLabel.BatteryVoltage:
                                    double voltage = device.getBatteryVoltage();
                                    lblBatteryVoltage.Text = $"{voltage:f2}v";
                                    batteryVoltageLogger.Add(time, voltage);
                                    batteryPlot.Refresh();
                                    break;
                            }
                            lstLog.SelectedIndex = lstLog.Items.Count - 1;

                        });
                    }
                    catch (Exception e)
                    {
                        lstLog.Items.Add("Error: " + e.Message);
                    }
                });
            }

        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            lstLog.Items.Clear();
        }

        private void GroundStation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connected)
            {
                device.Disconnect();
            }
        }
    }
}