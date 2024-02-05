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
                string message = "14318.3,15810.1,17.8204";
                byte[] bytes = Encoding.ASCII.GetBytes(message);
                client.Send(bytes, bytes.Length, new IPEndPoint(IPAddress.Loopback, 12345));
                Console.WriteLine(message);
                Thread.Sleep(1000);
            }
        }
    }
}