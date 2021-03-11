using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class Longitude
    {
        [XmlText]
        public string Value { get; set; }
    }
}