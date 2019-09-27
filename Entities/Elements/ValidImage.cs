using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class ValidImage
    {
        [XmlText]
        public string Value { get; set; }
    }
}