using System.Net;
using System.Net.Sockets;
using System.Text;

namespace A3MODSIM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                UdpClient client = new();
                string message = "{\"velocityVector\": [0, 0, 0], \"pos\": [14264.6, 15899.7, 18.0431], \"profileName\": \"kevin\", \"pitch\": 0, \"roll\": 0, \"dir\": 345.942, \"speed\": 0}";
                byte[] bytes = Encoding.ASCII.GetBytes(message);
                client.Send(bytes, bytes.Length, new IPEndPoint(IPAddress.Loopback, 12345));
                Console.WriteLine(message);
                Thread.Sleep(1000);
            }
        }
    }
}