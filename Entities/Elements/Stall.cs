using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class Stall
    {
        [XmlText]
        public string Value { get; set; }
    }
}