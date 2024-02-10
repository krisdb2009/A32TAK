using System.Xml;

namespace A32TAK
{
    public class COTBuilder
    {
        public XmlDocument Document = new();
        public COTBuilder(double Latitude, double Longitude)
        {
            XmlDeclaration delcaration = Document.CreateXmlDeclaration("1.0", null, "yes");
            Document.AppendChild(delcaration);
            XmlElement xEvent = Document.CreateElement("event");
            xEvent.AddAttribute("version", "2.0");
            xEvent.AddAttribute("uid", Guid.NewGuid().ToString());
            xEvent.AddAttribute("type", "a-f-G-E-S");
            xEvent.AddAttribute("time", DateTime.Now.ToString("s"));
            xEvent.AddAttribute("start", DateTime.Now.ToString("s"));
            xEvent.AddAttribute("stale", DateTime.Now.ToString("s"));
            xEvent.AddAttribute("how", "m-g");
            XmlElement point = Document.CreateElement("point");
            point.AddAttribute("lat", Latitude.ToString());
            point.AddAttribute("lon", Longitude.ToString());
            point.AddAttribute("hae", "-44.6");
            point.AddAttribute("ce", "0");
            point.AddAttribute("le", "0");
            xEvent.AppendChild(point);
            XmlElement precisionLocation = Document.CreateElement("precisionlocation");
            precisionLocation.AddAttribute("geopointsrc", "GPS");
            precisionLocation.AddAttribute("altitudesrc", "GPS");
            xEvent.AppendChild(precisionLocation);
            XmlElement track = Document.CreateElement("track");
            track.AddAttribute("course", "0");
            track.AddAttribute("speed", "0");
            xEvent.AppendChild(track);
            XmlElement remarks = Document.CreateElement("remarks");
            remarks.InnerText = "DylanGPS";
            xEvent.AppendChild(remarks);
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
