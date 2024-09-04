using System.Net;
using System.Net.Sockets;
using System.Text;

namespace A32TAK
{
    public class COTSender
    {
        public uint? UTMZone;
        public char? LatitudeBand;
        public char? GridSquareFirst;
        public char? GridSquareSecond;
        public double? GeoidHeight;
        public IPEndPoint? Target;
        private UdpClient UdpClient = new();
        public COTSender()
        {
            A32TAK.UdpListener.ReceivedData += UdpListener_ReceivedData;
        }
        private void UdpListener_ReceivedData(object? sender, ReceivedDataArgs e)
        {
            if (UTMZone == null) return;
            if (LatitudeBand == null) return;
            if (GridSquareFirst == null) return;
            if (GridSquareSecond == null) return;
            if (GeoidHeight == null) return;
            (double latitude, double longitude) = MGRSHelper.LatLongFromMGRS((uint)UTMZone, (char)LatitudeBand, (char)GridSquareFirst, (char)GridSquareSecond, (uint)e.X, (uint)e.Y);
            string cotXml = new COTBuilder(latitude, longitude, e.Direction, e.Speed / 3.6, (double)(e.Z + GeoidHeight)).Document.OuterXml;
            byte[] cotXmlBytes = Encoding.ASCII.GetBytes(cotXml);
            if (Target != null) UdpClient.Send(cotXmlBytes, cotXmlBytes.Length, Target);
        }
    }
}