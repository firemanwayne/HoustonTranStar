using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class Bus
    {
        [XmlText]
        public string Value { get; set; }
    }
}