using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class Location
    {
        [XmlText]
        public string Value { get; set; }
    }
}