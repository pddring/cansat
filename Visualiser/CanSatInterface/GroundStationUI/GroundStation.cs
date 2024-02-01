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
        DataLogger tempLogger;
        DataLogger altitudeLogger;

        private void GroundStation_Load(object sender, EventArgs e)
        {
            tempPlot = new ScottPlot.WinForms.FormsPlot();
            grpTempPlot.Controls.Add(tempPlot);
            tempPlot.Dock = DockStyle.Fill;
            tempLogger = tempPlot.Plot.Add.DataLogger();
            altitudeLogger = tempPlot.Plot.Add.DataLogger();
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
                                    lblPressure.Text = $"{device.getPressure()}hPa";
                                    tempPlot.Refresh();
                                    break;

                                case CanSatInterface.CanSatInterface.DataLabel.Altitude:
                                    double altitude = device.getAltitude();
                                    lblAltitude.Text = $"{altitude}m";
                                    altitudeLogger.Add(time, altitude);
                                    tempPlot.Refresh();
                                    break;
                            }
                            
                            lblAltitude.Text = $"{device.getAltitude()}m";
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
            if(connected)
            {
                device.Disconnect();
            }
        }
    }
}