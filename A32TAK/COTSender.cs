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
            (double latitude, double longitude) = MGRSHelper.LatLongFromMGRSString(18, 'S', 'X', 'E', (uint)e.X, (uint)e.Y);
            string cotXml = new COTBuilder(latitude, longitude).Document.OuterXml;
            byte[] cotXmlBytes = Encoding.ASCII.GetBytes(cotXml);
            if (Target != null) UdpClient.Send(cotXmlBytes, cotXmlBytes.Length, Target);
        }
    }
}