using System.Net;
using System.Net.Sockets;
using System.Text;

namespace A32TAK
{
    public class NMEASender
    {
        public IPEndPoint? Target;
        private UdpClient UdpClient = new();
        public NMEASender()
        {
            A32TAK.Math.MathDone += Instance_MathDone;
        }
        private void Instance_MathDone(object? sender, MathDoneEventArgs e)
        {
            string nmea = "$GPRMC,210230,A,3522.302,N,7344.041,W,0.0,360.0,040224,,,A,C*6A";
            //insert stuff

            byte[] nmeaBytes = Encoding.ASCII.GetBytes(nmea);
            UdpClient.Send(nmeaBytes, nmeaBytes.Length, Target);
        }
    }
}