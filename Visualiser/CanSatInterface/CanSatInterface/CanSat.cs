using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

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

            // GPS
            { "Fix", 0},  // GPS satellite fix
            { "Sat", 0},  // GPS satellite count
            { "3D", 0},   // 3d GPS satellite fix

            // Environment
            { "Press", 0},  // Air pressure (mb)
            { "Temp", 0},  // Air temperature (degrees C)
            { "Alt", 0},  // Altitude above starting level (m)

            // IMU
            { "AX", 0},  // Acceleration in x axis (m/s2)
            { "AY", 0},  // Acceleration in y axis (m/s2)
            { "AZ", 0},  // Acceleration in z axis (m/s2)
            { "MX", 0},  // Magnetic field strength in x axis 
            { "MY", 0},  // Magnetic field strength in y axis 
            { "MZ", 0},  // Magnetic field strength in z axis 
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
        /// <returns>Total running time since CanSat switched on</returns>
        public double getRunningTime()
        {
            return Values["T"];
        }

        /// <summary>
        /// Gets the latest packet number
        /// </summary>
        /// <returns>Latest packet number</returns>
        public int getLatestPacketNumber()
        {
            return (int)Values["P"];
        }

        /// <summary>
        /// Gets the latest battery voltage
        /// Min: 3
        /// Nominal: 3.7
        /// Max: 4.2
        /// </summary>
        /// <returns>Battery voltage</returns>
        public double getBatteryVoltage()
        {
            return Values["Batt"];
        }

        public enum GPSFixType
        {
            GPSFix2D,
            GPSFix3D
        }

        /// <summary>
        /// Checks if CanSat has a fix on GPS satellites
        /// </summary>
        /// <param name="fixType">2d (just lat/lng) or 3d (altitude) GPS fix</param>
        /// <returns>true if GPS signal received from sufficient satellites</returns>
        public bool hasGPSFix(GPSFixType fixType=GPSFixType.GPSFix2D)
        {
            if(fixType == GPSFixType.GPSFix3D)
            {
                return Values["3D"] > 0;
            }
            return Values["2D"] > 0;
        }

        /// <summary>
        /// Checks if CanSat is currently plugged in to USB and is charging
        /// </summary>
        /// <returns>true if charging</returns>
        public bool isCharging()
        {
            return Values["Char"] > 0;
        }

        /// <summary>
        /// Gets latest pressure value
        /// </summary>
        /// <returns>Pressure in hPa</returns>
        public double getPressure()
        {
            return Values["Press"];
        }

        /// <summary>
        /// Gets the latest temperature value
        /// </summary>
        /// <returns>Temperature in 'C</returns>
        public double getTemperature()
        {
            return Values["Temp"];
        }
        
        /// <summary>
        /// Gets the latest altitude value
        /// This is a calculated value from the pressure - not an absolute value
        /// CanSat will assume an altitude of 0 when switched on.
        /// </summary>
        /// <returns>Altitude (m)</returns>
        public double getAltitude()
        {
            return Values["Alt"];
        }

        /// <summary>
        /// Gets latest acceleration readings from the inertial measurement unit
        /// </summary>
        /// <returns>Array of X, Y an Z acceleration (m/s2)</returns>
        public double[] getAcceleration()
        {
            double[] acceleration = new double[3]
            {
                Values["AX"], Values["AY"], Values["AZ"]
            };
            return acceleration;
        }

        /// <summary>
        /// Gets latest magnetometer readings from the inertial measurement unit
        /// </summary>
        /// <returns>Array of X, Y an Z magnetic field strength (uT)</returns>
        public double[] getMagneticFieldStrength()
        {
            double[] magneticFieldstrength = new double[3]
            {
                Values["MX"], Values["MY"], Values["MZ"]
            };
            return magneticFieldstrength;
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
                    Match m = Regex.Match(data, @"([0-9A-Za-z]+): (-?\d+\.?\d*)");
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
