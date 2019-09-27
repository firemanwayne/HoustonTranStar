using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class Name
    {
        [XmlText]
        public string Value { get; set; }
    }
}