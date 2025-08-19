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
        public IPEndPoint? UnicastTarget;
        public IPEndPoint MulticastTarget = new(IPAddress.Parse("239.2.3.1"), 6969);
        private readonly UdpClient UdpClient = new();
        public COTSender()
        {
            A32TAK.UdpListener.ReceivedData += UdpListener_ReceivedData;
        }
        private void UdpListener_ReceivedData(object? sender, Game.Message e)
        {
            if (UTMZone == null) return;
            if (LatitudeBand == null) return;
            if (GridSquareFirst == null) return;
            if (GridSquareSecond == null) return;
            if (GeoidHeight == null) return;
            
            (double playerLatitude, double playerLongitude) = MGRSHelper.LatLongFromMGRS((uint)UTMZone, (char)LatitudeBand, (char)GridSquareFirst, (char)GridSquareSecond, (uint)e.Player.Position[0], (uint)e.Player.Position[1]);
            string playerCotXml = COTBuilders.BuildPlayerCOT(playerLatitude, playerLongitude, e.Player.Direction, e.Player.Speed / 3.6, (double)(e.Player.Position[2] + GeoidHeight)).OuterXml;
            byte[] playerCotXmlBytes = Encoding.ASCII.GetBytes(playerCotXml);
            if (UnicastTarget != null) UdpClient.Send(playerCotXmlBytes, playerCotXmlBytes.Length, UnicastTarget);

            string droneCotXml = string.Empty;
            if (e.Drone != null)
            {
                (double droneLatitude, double droneLongitude) = MGRSHelper.LatLongFromMGRS((uint)UTMZone, (char)LatitudeBand, (char)GridSquareFirst, (char)GridSquareSecond, (uint)e.Drone.Value.Position[0], (uint)e.Drone.Value.Position[1]);
                droneCotXml = COTBuilders.BuildDroneCOT(droneLatitude, droneLongitude, e.Drone.Value.Direction, e.Drone.Value.Speed / 3.6, (double)(e.Drone.Value.Position[2] + GeoidHeight), e.Drone.Value.Name).OuterXml;
                byte[] droneCotXmlBytes = Encoding.ASCII.GetBytes(playerCotXml);
                UdpClient.Send(droneCotXmlBytes, droneCotXmlBytes.Length, MulticastTarget);
            }

            if (A32TAK.MainWindow.DebugMode)
            {
                Logger.Log(playerCotXml, Color.MediumPurple);
                Logger.Log(droneCotXml, Color.PeachPuff);
            }
        }
    }
}