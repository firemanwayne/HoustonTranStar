using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class OriginRoad
    {
        [XmlText]
        public string Value { get; set; }
    }
}