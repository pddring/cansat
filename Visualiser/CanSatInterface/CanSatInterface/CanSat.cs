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

    public class CanSat
    {
        private SerialPort port;
        private ProcessData externalHandler;

        Dictionary<string, double> Values = new Dictionary<string, double>()
        {
            // general
            { "T", 0 }, // time (s)
            { "R", 0 }, // recording remotely
            { "P", 0 }, // packet number
            
            // battery
            { "Char", 0}, // battery is charging
            { "Batt", 0}, // battery voltage (v)
        };

        public void ShowValues()
        {
            foreach(string k in Values.Keys)
            {
                Console.WriteLine($"{k}: {Values[k]}");
            }
        }

        /// <summary>
        /// Checks if the CanSat device is logging values on the satellite itself
        /// </summary>
        /// <returns>true if data values are being logged to CSV files</returns>
        public bool isRecordingRemotely()
        {
            return Values["R"] > 0;
        }

        /// <summary>
        /// Gets total running time in seconds
        /// </summary>
        /// <returns></returns>
        public double getRunningTime()
        {
            return Values["T"];
        }

        public CanSat(string PortName)
        {
            port = new SerialPort(PortName, 115200, Parity.None, 8);
        }

        
        public void Connect(ProcessData OnDataReceived)
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
                    Match m = Regex.Match(data, @"([A-Za-z]+): (-?\d+\.?\d*)");
                    if(m.Success)
                    {
                        string label = m.Groups[1].Value;
                        double value = double.Parse(m.Groups[2].Value);
                        Values[label] = value;
                    }
                    externalHandler(data);
                    break;
            }
        }

        public void Disconnect()
        {
            port.Close();
        }
    }
}
