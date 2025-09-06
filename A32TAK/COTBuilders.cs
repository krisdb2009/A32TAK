using System.Xml;

namespace A32TAK
{
    public static class COTBuilders
    {
        private static readonly DateTime StartTime = DateTime.UtcNow;
        private static readonly uint StaleTimeSeconds = 3;
        private static readonly Guid PlayerGuid = Guid.NewGuid();
        private static readonly Guid DroneGuid = Guid.NewGuid();
        private static readonly Guid SpiGuid = Guid.NewGuid();
        public static XmlDocument BuildPlayerCOT(double Latitude, double Longitude, double Direction, double Speed, double Height)
        {
            XmlDocument document = new();
            XmlDeclaration xDeclaration = document.CreateXmlDeclaration("1.0", null, "yes");
            document.AppendChild(xDeclaration);
            XmlElement xEvent = document.CreateElement("event");
            xEvent.AddAttribute("xmlns", "urn:cot:message:2.0");
            xEvent.AddAttribute("version", "2.0");
            xEvent.AddAttribute("uid", PlayerGuid.ToString());
            xEvent.AddAttribute("type", "a-f-G-E-S");
            xEvent.AddAttribute("time", DateTime.UtcNow.ToString("s") + 'Z');
            xEvent.AddAttribute("start", StartTime.ToString("s") + 'Z');
            xEvent.AddAttribute("stale", DateTime.UtcNow.AddSeconds(StaleTimeSeconds).ToString("s") + 'Z');
            xEvent.AddAttribute("how", "m-g");
            XmlElement xPoint = document.CreateElement("point");
            xPoint.AddAttribute("lat", Latitude.ToString());
            xPoint.AddAttribute("lon", Longitude.ToString());
            xPoint.AddAttribute("hae", Height.ToString());
            xPoint.AddAttribute("ce", "0");
            xPoint.AddAttribute("le", "0");
            xEvent.AppendChild(xPoint);
            XmlElement xDetail = document.CreateElement("detail");
            XmlElement xPrecisionLocation = document.CreateElement("precisionlocation");
            xPrecisionLocation.AddAttribute("geopointsrc", "GPS");
            xPrecisionLocation.AddAttribute("altitudesrc", "GPS");
            xDetail.AppendChild(xPrecisionLocation);
            XmlElement xTrack = document.CreateElement("track");
            xTrack.AddAttribute("course", Direction.ToString());
            xTrack.AddAttribute("speed", Speed.ToString());
            xDetail.AppendChild(xTrack);
            XmlElement xRemarks = document.CreateElement("remarks");
            xRemarks.InnerText = "A32TAK";
            xDetail.AppendChild(xRemarks);
            xEvent.AppendChild(xDetail);
            document.AppendChild(xEvent);
            return document;
        }
        public static XmlDocument BuildDroneCOT(double Latitude, double Longitude, double Direction, double Speed, double Height, string Callsign)
        {
            XmlDocument document = new();
            XmlDeclaration xDeclaration = document.CreateXmlDeclaration("1.0", null, "yes");
            document.AppendChild(xDeclaration);
            XmlElement xEvent = document.CreateElement("event");
            xEvent.AddAttribute("xmlns", "urn:cot:message:2.0");
            xEvent.AddAttribute("version", "2.0");
            xEvent.AddAttribute("uid", DroneGuid.ToString());
            xEvent.AddAttribute("type", "a-f-A-M-H-Q");
            xEvent.AddAttribute("time", DateTime.UtcNow.ToString("s") + 'Z');
            xEvent.AddAttribute("start", StartTime.ToString("s") + 'Z');
            xEvent.AddAttribute("stale", DateTime.UtcNow.AddSeconds(StaleTimeSeconds).ToString("s") + 'Z');
            xEvent.AddAttribute("how", "m-g");
            XmlElement xPoint = document.CreateElement("point");
            xPoint.AddAttribute("lat", Latitude.ToString());
            xPoint.AddAttribute("lon", Longitude.ToString());
            xPoint.AddAttribute("hae", Height.ToString());
            xPoint.AddAttribute("ce", "0");
            xPoint.AddAttribute("le", "0");
            xEvent.AppendChild(xPoint);
            XmlElement xDetail = document.CreateElement("detail");
            XmlElement xContact = document.CreateElement("contact");
            xContact.AddAttribute("callsign", Callsign);
            xDetail.AppendChild(xContact);
            XmlElement xPrecisionLocation = document.CreateElement("precisionlocation");
            xPrecisionLocation.AddAttribute("altsrc", "GPS");
            xPrecisionLocation.AddAttribute("geodetic_datum", "WGS84");
            xDetail.AppendChild(xPrecisionLocation);
            XmlElement xTrack = document.CreateElement("track");
            xTrack.AddAttribute("course", Direction.ToString());
            xTrack.AddAttribute("speed", Speed.ToString());
            xDetail.AppendChild(xTrack);
            XmlElement xRemarks = document.CreateElement("remarks");
            xRemarks.InnerText = "A32TAK";
            xDetail.AppendChild(xRemarks);
            xEvent.AppendChild(xDetail);
            document.AppendChild(xEvent);
            return document;
        }
        public static XmlDocument BuildSpiCOT(double Latitude, double Longitude, double Height)
        {
            XmlDocument document = new();
            XmlDeclaration xDeclaration = document.CreateXmlDeclaration("1.0", null, "yes");
            document.AppendChild(xDeclaration);
            XmlElement xEvent = document.CreateElement("event");
            xEvent.AddAttribute("xmlns", "urn:cot:message:2.0");
            xEvent.AddAttribute("version", "2.0");
            xEvent.AddAttribute("uid", SpiGuid.ToString());
            xEvent.AddAttribute("type", "b-m-p-s-p-i");
            xEvent.AddAttribute("time", DateTime.UtcNow.ToString("s") + 'Z');
            xEvent.AddAttribute("start", StartTime.ToString("s") + 'Z');
            xEvent.AddAttribute("stale", DateTime.UtcNow.AddSeconds(StaleTimeSeconds).ToString("s") + 'Z');
            xEvent.AddAttribute("how", "m-g");
            XmlElement xPoint = document.CreateElement("point");
            xPoint.AddAttribute("lat", Latitude.ToString());
            xPoint.AddAttribute("lon", Longitude.ToString());
            xPoint.AddAttribute("hae", Height.ToString());
            xPoint.AddAttribute("ce", "0");
            xPoint.AddAttribute("le", "0");
            xEvent.AppendChild(xPoint);
            XmlElement xDetail = document.CreateElement("detail");
            XmlElement xLink = document.CreateElement("link");
            xLink.AddAttribute("relation", "p-p");
            xLink.AddAttribute("uid", DroneGuid.ToString());
            xLink.AddAttribute("type", "a-f-A-U-Q");
            xDetail.AppendChild(xLink);
            XmlElement xRemarks = document.CreateElement("remarks");
            xRemarks.InnerText = "A32TAK";
            xDetail.AppendChild(xRemarks);
            xEvent.AppendChild(xDetail);
            document.AppendChild(xEvent);
            return document;
        }
    }
    public static class XmlHelpers
    {
        public static void AddAttribute(this XmlElement Parent, string Name, string Value)
        {
            XmlAttribute attribute = Parent.OwnerDocument.CreateAttribute(Name);
            attribute.Value = Value;
            Parent.Attributes?.Append(attribute);
        }
    }
}