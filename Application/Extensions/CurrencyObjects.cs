using System.Xml.Serialization;

namespace Application.Clients.Extensions
{
    [XmlRoot(ElementName = "Cube")]
    public class RootCube
    {
        [XmlElement(ElementName = "Cube")]
        public required List<TimeCube> TimeCubes { get; set; }
    }

    public class TimeCube
    {
        [XmlAttribute(AttributeName = "time")]
        public DateTime Time { get; set; }

        [XmlElement(ElementName = "Cube")]
        public required List<CurrencyCube> CurrencyCubes { get; set; }
    }

    public class CurrencyCube
    {
        [XmlAttribute(AttributeName = "currency")]
        public required string Currency { get; set; }

        [XmlAttribute(AttributeName = "rate")]
        public decimal Rate { get; set; }
    }
}