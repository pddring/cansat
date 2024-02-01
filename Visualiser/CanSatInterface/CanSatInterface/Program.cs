using System.IO.Ports;
using CanSatInterface;

internal class Program
{
    private static void Main(string[] args)
    {
        // connect to the highest numbered COM port
        Console.WriteLine("Searching for COM ports:");
        string[] portNames = SerialPort.GetPortNames();
        string chosenPort = "";
        foreach (string name in portNames)
        {
            Console.WriteLine($"Found port: {name}");
            chosenPort = name;
        }

        if(chosenPort == "") {
            Console.WriteLine("no COM ports found - please make sure CanSat is plugged in");
            return;
        }

        Console.WriteLine($"Attempting to connect to {chosenPort}");
        CanSatSimulatedTest cansat = new CanSatSimulatedTest(chosenPort);
        
        // Listen for data and display it when received
        cansat.Connect((string data, CanSat.DataLabel lastUpdated) =>
        {
            Console.WriteLine($"Received: {data}");
        });

        // wait until the user presses enter
        Console.ReadLine();
        cansat.Disconnect();

        cansat.ShowValues();
    }
}