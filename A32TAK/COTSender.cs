using System.Net;
using System.Net.Sockets;
using System.Text;

namespace A32TAK
{
    public class COTSender
    {
        public IPEndPoint? Target;
        private UdpClient UdpClient = new();
        public COTSender()
        {
            A32TAK.UdpListener.ReceivedData += UdpListener_ReceivedData; ;
        }

        private void UdpListener_ReceivedData(object? sender, ReceivedDataArgs e)
        {


            string cotXml = new COTBuilder(35.371700, -73.734031).Document.OuterXml;

            byte[] cotXmlBytes = Encoding.ASCII.GetBytes(cotXml);
            if (Target != null) UdpClient.Send(cotXmlBytes, cotXmlBytes.Length, Target);
        }
        /*
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
        */
    }
}