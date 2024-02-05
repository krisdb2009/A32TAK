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
            //string nmea = "$GPRMC,210230,A,3522.302,N,07344.041,W,,,050224,000.0,W*67";
            //insert stuff

            string nmea = A32TAK.MainWindow.tbNMEA.Text;
            string? nmeaWithChecksum = CalculateChecksum(nmea);
            if (nmeaWithChecksum == null) return;
            byte[] nmeaBytes = Encoding.ASCII.GetBytes(nmeaWithChecksum);
            if (Target != null) UdpClient.Send(nmeaBytes, nmeaBytes.Length, Target);
        }
        private string? CalculateChecksum(string NMEA)
        {
            string content = NMEA;
            if (NMEA.Length < 3) return null;
            if (NMEA[0] != '$') return null;
            if (NMEA.Last() != '*') return null;
            content = content.Remove(0, 1);
            content = content.Remove(content.Length - 1, 1);
            byte[] bytes = Encoding.ASCII.GetBytes(content);
            byte checksum = 0;
            foreach (byte nmeaByte in bytes)
            {
                checksum = (byte)(nmeaByte ^ checksum);
            }
            return NMEA + BitConverter.ToString(new[] { checksum });
        }
    }
}