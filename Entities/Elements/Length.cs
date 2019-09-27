using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class Length
    {
        [XmlText]
        public string Value { get; set; }
    }
}