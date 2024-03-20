using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace CanSatInterface
{

    public delegate void ProcessData(string data, CanSat.DataLabel lastUpdated);

    public class CanSat: CanSatInterface
    {
        private SerialPort port;

        
        public CanSat(string PortName)
        {
            port = new SerialPort(PortName, 115200, Parity.None, 8);
        }

        public override void Connect(ProcessData OnDataReceived)
        {
            port.Open();
            //port.DataReceived += Port_DataReceived;
            externalHandler = OnDataReceived;
            port.DtrEnable = true;
            port.RtsEnable = true;
            
            Thread t = new Thread(() =>
            {
                while (port.IsOpen)
                {
                    try
                    {
                        string data = port.ReadLine();
                        ProcessData(data);
                    }
                    catch (Exception ex)
                    {
                        port.Close();
                    }
                    
                }
            });
            t.Start();
            
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            switch(e.EventType)
            {
                case SerialData.Chars:
                    while (port.BytesToRead > 0)
                    {
                        string data = port.ReadLine();
                        ProcessData(data);
                    }
                    break;
                default:
                    Debug.WriteLine("Error!");
                    break;
            }
        }

        public override void Disconnect()
        {
            port.Close();
        }
    }
}
