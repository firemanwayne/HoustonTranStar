using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class RoadDebris
    {
        [XmlText]
        public string Value { get; set; }
    }
}