using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class Accident
    {
        [XmlText]
        public string Value { get; set; }
    }
}