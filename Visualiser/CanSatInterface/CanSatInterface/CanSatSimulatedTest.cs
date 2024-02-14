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
            double ax = 0, ay = 9.81, az = 0;
            double mx = 0, my = 0, mz = 0;
            double batt = 4.1;

            int remote = 0;
            while (thisDevice.isConnected)
            {
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
                    p++;
                    s = DateTime.Now - thisDevice.startTime;
                    Thread.Sleep(100);

                    //AX:{:.3f} AY:{:.3f} AZ:{:.3f} P:{} R:{} T:{}
                    ax += r.NextDouble() - .5;
                    ay += r.NextDouble() - .5;
                    az += r.NextDouble() - .5;
                    thisDevice.ProcessData($"AX: {ax:f2}");
                    thisDevice.ProcessData($"AY: {ay:f2}");
                    thisDevice.ProcessData($"AZ: {az:f2}");
                    thisDevice.ProcessData($"P: {p}");
                    thisDevice.ProcessData($"R: {remote}");
                    thisDevice.ProcessData($"T: {s.TotalSeconds:f2}");
                    p++;
                    s = DateTime.Now - thisDevice.startTime;
                    Thread.Sleep(100);

                    //MX:{:.3f} MY:{:.3f} MZ:{:.3f} P:{} R:{} T:{} 
                    mx += r.NextDouble() - .5;
                    my += r.NextDouble() - .5;
                    mz += r.NextDouble() - .5;
                    thisDevice.ProcessData($"MX: {mx:f2}");
                    thisDevice.ProcessData($"MY: {my:f2}");
                    thisDevice.ProcessData($"MZ: {mz:f2}");
                    thisDevice.ProcessData($"P: {p}");
                    thisDevice.ProcessData($"R: {remote}");
                    thisDevice.ProcessData($"T: {s.TotalSeconds:f2}");
                    p++;
                    s = DateTime.Now - thisDevice.startTime;
                    Thread.Sleep(100);

                    //Batt:{} Char:{} P:{} R:{} T:{} 
                    batt -= r.NextDouble() / 10000;
                    thisDevice.ProcessData($"Batt: {batt:f2}");
                    thisDevice.ProcessData($"Char: {0}");
                    thisDevice.ProcessData($"P: {p}");
                    thisDevice.ProcessData($"R: {remote}");
                    thisDevice.ProcessData($"T: {s.TotalSeconds:f2}");
                    p++;
                    s = DateTime.Now - thisDevice.startTime;
                    Thread.Sleep(100);
                }
            }
        }
    }
}
