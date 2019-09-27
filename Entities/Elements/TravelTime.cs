using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class TravelTime
    {
        [XmlText]
        public string Value { get; set; }
    }
}