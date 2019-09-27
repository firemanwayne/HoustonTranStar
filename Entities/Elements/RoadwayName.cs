using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class RoadwayName
    {
        [XmlText]
        public string Value { get; set; }
    }
}