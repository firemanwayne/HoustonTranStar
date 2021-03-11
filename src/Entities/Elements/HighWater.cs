using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class HighWater
    {
        [XmlText]
        public string Value { get; set; }
    }
}