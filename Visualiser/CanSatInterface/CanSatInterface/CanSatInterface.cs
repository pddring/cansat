using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CanSatInterface
{
    public abstract class CanSatInterface
    {
        public enum DataLabel
        {
            Time,
            RecordingRemotely,
            PacketNumber,
            BatteryCharging,
            BatteryVoltage,
            GPS2DFix,
            GPSSatelliteCount,
            GPS3DFix,
            Pressure,
            Temperature,
            Altitude,
            AccelerationX,
            AccelerationY,
            AccelerationZ,
            MagneticFieldStrengthX,
            MagneticFieldStrengthY,
            MagneticFieldStrengthZ,
            Unknown
        }

        protected Dictionary<string, double> Values = new Dictionary<string, double>()
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

        protected ProcessData externalHandler;

        public void ShowValues()
        {
            foreach (string k in Values.Keys)
            {
                Console.WriteLine($"{k}: {Values[k]}");
            }
        }

        protected DataLabel ProcessData(string data)
        {
            Match m = Regex.Match(data, @"([A-Za-z]+): (-?\d+\.?\d*)");
            DataLabel lastUpdated = DataLabel.Unknown;
            if (m.Success)
            {
                string label = m.Groups[1].Value;
                double value = double.Parse(m.Groups[2].Value);
                Values[label] = value;

                switch (label)
                {
                    case "T":
                        lastUpdated = DataLabel.Time;
                        break;
                    case "R":
                        lastUpdated = DataLabel.RecordingRemotely;
                        break;
                    case "P":
                        lastUpdated = DataLabel.PacketNumber;
                        break;

                    // battery
                    case "Char":
                        lastUpdated = DataLabel.BatteryCharging;
                        break;
                    case "Batt":
                        lastUpdated = DataLabel.BatteryVoltage;
                        break;

                    // GPS
                    case "Fix":
                        lastUpdated = DataLabel.GPS2DFix;
                        break;
                    case "Sat":
                        lastUpdated = DataLabel.GPSSatelliteCount;
                        break;
                    case "3D":
                        lastUpdated = DataLabel.GPS3DFix;
                        break;

                    // Environment
                    case "Press":
                        lastUpdated = DataLabel.Pressure;
                        break;
                    case "Temp":
                        lastUpdated = DataLabel.Temperature;
                        break;
                    case "Alt":
                        lastUpdated = DataLabel.Altitude;
                        break;

                    // IMU
                    case "AX":
                        lastUpdated = DataLabel.AccelerationX;
                        break;
                    case "AY":
                        lastUpdated = DataLabel.AccelerationY;
                        break;
                    case "AZ":
                        lastUpdated = DataLabel.AccelerationZ;
                        break;
                    case "MX":
                        lastUpdated = DataLabel.MagneticFieldStrengthX;
                        break;
                    case "MY":
                        lastUpdated = DataLabel.MagneticFieldStrengthY;
                        break;
                    case "MZ":
                        lastUpdated = DataLabel.MagneticFieldStrengthZ;
                        break;
                }
            }
            if (externalHandler != null)
                externalHandler(data, lastUpdated);
            return lastUpdated;
        }

        /// <summary>
        /// Gets an array of acceleration readings from the IMU
        /// </summary>
        /// <returns>Array of X, Y and Z readings in m/s²</returns>
        public double[] getAcceleration()
        {
            double[] a = new double[3]
            {
                Values["AX"], Values["AY"], Values["AZ"]
            };
            return a;
        }

        /// <summary>
        /// Gets an array of magnetometer readings from the IMU
        /// </summary>
        /// <returns>Array of X, Y and Z readings in uT</returns>
        public double[] getMagneticFieldStrength()
        {
            double[] m = new double[3]
            {
                Values["MX"], Values["MY"], Values["MZ"]
            };
            return m;
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
        /// Gets the current pressure
        /// </summary>
        /// <returns>Pressure in hPa</returns>
        public double getPressure()
        {
            return Values["Press"];
        }

        /// <summary>
        /// Gets the current altitude
        /// This is a calculated value from the pressure rather than an absolute measure
        /// The CanSat sensor will set this value to 0 when first switched on so values
        /// will be relative to that altitude but also affected by changes in air pressure.
        /// </summary>
        /// <returns>Altitude in m (above starting point)</returns>
        public double getAltitude()
        {
            return Values["Alt"];
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

        /// <summary>
        /// Gets the current battery voltage. Should be between 3.7 and 4.2v
        /// </summary>
        /// <returns>Voltage (v)</returns>
        public double getBatteryVoltage()
        {
            return Values["Batt"];
        }
    }
}
