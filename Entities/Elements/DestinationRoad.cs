using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class DestinationRoad
    {
        [XmlText]
        public string Value { get; set; }
    }
}