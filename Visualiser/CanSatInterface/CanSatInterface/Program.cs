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

        Console.WriteLine($"Attempting to connect to {chosenPort}");
        CanSat cansat = new CanSat(chosenPort);
        
        // Listen for data and display it when received
        cansat.Connect((string data) =>
        {
            Console.WriteLine($"Received: {data}");
        });

        // wait until the user presses enter
        Console.ReadLine();
        cansat.Disconnect();
    }
}