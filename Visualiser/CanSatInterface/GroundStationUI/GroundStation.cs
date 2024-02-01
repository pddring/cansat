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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string[] portNames = SerialPort.GetPortNames();
            lstDevices.Items.Clear();
            foreach (string deviceName in portNames)
            {
                lstDevices.Items.Add(deviceName);
            }
            lstDevices.Items.Add(SIMULATED_DEVICE_NAME);
        }
        ScottPlot.WinForms.FormsPlot tempPlot;

        private void GroundStation_Load(object sender, EventArgs e)
        {
            tempPlot = new ScottPlot.WinForms.FormsPlot();
            grpTempPlot.Controls.Add(tempPlot);
            tempPlot.Dock = DockStyle.Fill;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(connected)
            {
                connected = false;
                btnConnect.Text = "&Connect";
                device.Disconnect();
            } else
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
                device.Connect((string data) =>
                {
                    lstLog.Invoke(() =>
                    {
                        lstLog.Items.Add(data);
                    });
                });
            }
            
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            lstLog.Items.Clear();
        }
    }
}