using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CanSatInterface
{

    public delegate void ProcessData(string data);

    public class CanSat: CanSatInterface
    {
        private SerialPort port;

        public void ShowValues()
        {
            foreach(string k in Values.Keys)
            {
                Console.WriteLine($"{k}: {Values[k]}");
            }
        }
        public CanSat(string PortName)
        {
            port = new SerialPort(PortName, 115200, Parity.None, 8);
        }

        
        public override void Connect(ProcessData OnDataReceived)
        {
            port.Open();
            port.DataReceived += Port_DataReceived;
            externalHandler = OnDataReceived;
            port.DtrEnable = true;
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            switch(e.EventType)
            {
                case SerialData.Chars:
                    string data = port.ReadLine();
                    ProcessData(data);
                    break;
            }
        }

        public override void Disconnect()
        {
            port.Close();
        }
    }
}
