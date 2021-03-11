using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class HeavyTruck
    {
        [XmlText]
        public string Value { get; set; }
    }
}