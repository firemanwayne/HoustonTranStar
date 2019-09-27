using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class Latitude
    {
        [XmlText]
        public string Value { get; set; }
    }
}