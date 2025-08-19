using System.Net;
using System.Net.Sockets;
using System.Text;

namespace A3MODSIM
{
    internal class Program
    {
        static readonly Random RNG = new();
        static readonly string[] Messages = [
            "{\"player\":{\"position\":[9178.74,11437.3,109.852], \"speed\":1, \"direction\":295.327}, \"controlling_drone\": false, \"drone\":null, \"drone_using_laser\": false, \"laser_position\":null}",
            "{\"player\":{\"position\":[9178.74,11437.3,109.852], \"speed\":2, \"direction\":295.327}, \"controlling_drone\": true, \"drone\":{\"name\":\"AR-2 Darter\", \"position\":[9184.47,11445.3,445.056], \"speed\":5.78155e-08, \"direction\":298.764}, \"drone_using_laser\": false, \"laser_position\":null}",
            "{\"player\":{\"position\":[9178.74,11437.3,109.852], \"speed\":3, \"direction\":295.327}, \"controlling_drone\": true, \"drone\":{\"name\":\"AR-2 Darter\", \"position\":[9184.47,11445.3,445.055], \"speed\":5.69707e-09, \"direction\":298.768}, \"drone_using_laser\": true, \"laser_position\":[7365.06,13174.9,156.958]}"
        ];
        static void Main(string[] _1)
        {
            while (true)
            {
                UdpClient client = new();
                int index = RNG.Next(Messages.Length);
                string message = Messages[index];
                byte[] bytes = Encoding.ASCII.GetBytes(message);
                client.Send(bytes, bytes.Length, new IPEndPoint(IPAddress.Loopback, 12345));
                Console.WriteLine(message);
                Thread.Sleep(300);
            }
        }
    }
}