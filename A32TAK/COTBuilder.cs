using System.Xml;

namespace A32TAK
{
    public class COTBuilder
    {
        public XmlDocument Document = new();
        public COTBuilder(double Latitude, double Longitude, double Direction, double Speed, double Height)
        {
            XmlDeclaration xDeclaration = Document.CreateXmlDeclaration("1.0", null, "yes");
            Document.AppendChild(xDeclaration);
            XmlElement xEvent = Document.CreateElement("event");
            xEvent.AddAttribute("version", "2.0");
            xEvent.AddAttribute("uid", Guid.NewGuid().ToString());
            xEvent.AddAttribute("type", "a-f-G-E-S");
            xEvent.AddAttribute("time", DateTime.UtcNow.ToString("s"));
            xEvent.AddAttribute("start", DateTime.UtcNow.ToString("s"));
            xEvent.AddAttribute("stale", DateTime.UtcNow.AddMinutes(1).ToString("s"));
            xEvent.AddAttribute("how", "m-g");
            XmlElement xPoint = Document.CreateElement("point");
            xPoint.AddAttribute("lat", Latitude.ToString());
            xPoint.AddAttribute("lon", Longitude.ToString());
            xPoint.AddAttribute("hae", Height.ToString());
            xPoint.AddAttribute("ce", "0");
            xPoint.AddAttribute("le", "0");
            xEvent.AppendChild(xPoint);
            XmlElement xDetail = Document.CreateElement("detail");
            XmlElement xPrecisionLocation = Document.CreateElement("precisionlocation");
            xPrecisionLocation.AddAttribute("geopointsrc", "GPS");
            xPrecisionLocation.AddAttribute("altitudesrc", "GPS");
            xDetail.AppendChild(xPrecisionLocation);
            XmlElement xTrack = Document.CreateElement("track");
            xTrack.AddAttribute("course", Direction.ToString());
            xTrack.AddAttribute("speed", Speed.ToString());
            xDetail.AppendChild(xTrack);
            XmlElement xRemarks = Document.CreateElement("remarks");
            xRemarks.InnerText = "A32TAK";
            xDetail.AppendChild(xRemarks);
            xEvent.AppendChild(xDetail);
            Document.AppendChild(xEvent);
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
