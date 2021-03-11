using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class Other
    {
        [XmlText]
        public string Value { get; set; }
    }
}