using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CanSatInterface
{
    public class CanSatSimulatedTest : CanSatInterface
    {
        protected bool isConnected = false;
        DateTime startTime;
        public CanSatSimulatedTest(string pretendComPortName)
        {
            Console.WriteLine($"Initialising simulated CanSat device (no real connection to COM port)");
        }

        public override void Connect(ProcessData OnDataReceived)
        {
            externalHandler = OnDataReceived;
            startTime = DateTime.Now;
            isConnected = true;
            Thread background = new Thread(CanSatSimulatedTest.BackgroundTask);
            background.Start(this);
        }

        public override void Disconnect()
        {
            isConnected = false;
        }

        public static void BackgroundTask(object device)
        {
            CanSatSimulatedTest thisDevice = (CanSatSimulatedTest)device;
            int p = 0;
            Random r = new Random();
            double temp = 23;
            double pressure = 1000;
            double altitude = 20;

            int remote = 0;
            while (thisDevice.isConnected)
            {
                Thread.Sleep(1000);
                TimeSpan s = DateTime.Now - thisDevice.startTime;
                if(thisDevice.externalHandler != null)
                {
                    thisDevice.ProcessData($"Fix: {0}");
                    thisDevice.ProcessData($"3D: {0}");
                    thisDevice.ProcessData($"Sat: {0}");
                    thisDevice.ProcessData($"P: {p}");
                    thisDevice.ProcessData($"R: {remote}");
                    thisDevice.ProcessData($"T: {s.TotalSeconds:f2}");
                    p++;

                    s = DateTime.Now - thisDevice.startTime;
                    Thread.Sleep(100);

                    temp += r.NextDouble() - .5;
                    pressure += r.NextDouble() - .5;
                    altitude += r.NextDouble() - .5;
                    thisDevice.ProcessData($"Temp: {temp:f2}");
                    thisDevice.ProcessData($"Press: {pressure:f2}");
                    thisDevice.ProcessData($"Alt: {altitude:f2}");
                    thisDevice.ProcessData($"P: {p}");
                    thisDevice.ProcessData($"R: {remote}");
                    thisDevice.ProcessData($"T: {s.TotalSeconds:f2}");

                }
            }
        }
    }
}
