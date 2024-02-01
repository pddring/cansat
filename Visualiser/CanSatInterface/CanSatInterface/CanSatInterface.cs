using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CanSatInterface
{
    public abstract class CanSatInterface
    {
        protected Dictionary<string, double> Values = new Dictionary<string, double>()
        {
            // general
            { "T", 0 }, // time (s)
            { "R", 0 }, // recording remotely
            { "P", 0 }, // packet number
            
            // battery
            { "Char", 0}, // battery is charging
            { "Batt", 0}, // battery voltage (v)

            // bmp280
            { "Temp", 0}, // temperature
        };

        protected ProcessData externalHandler;

        public void ShowValues()
        {
            foreach (string k in Values.Keys)
            {
                Console.WriteLine($"{k}: {Values[k]}");
            }
        }

        protected void ProcessData(string data)
        {
            Match m = Regex.Match(data, @"([A-Za-z]+): (-?\d+\.?\d*)");
            if (m.Success)
            {
                string label = m.Groups[1].Value;
                double value = double.Parse(m.Groups[2].Value);
                Values[label] = value;
            }
            if (externalHandler != null)
                externalHandler(data);
        }

        /// <summary>
        /// Gets the current temperature
        /// </summary>
        /// <returns>Temperature in degrees C</returns>
        public double getTemperature()
        {
            return Values["Temp"];
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


        abstract public void Connect(ProcessData OnDataReceived);

        abstract public void Disconnect();
    }
}
