using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class DestinationDirection
    {
        [XmlText]
        public string Value { get; set; }
    }
}