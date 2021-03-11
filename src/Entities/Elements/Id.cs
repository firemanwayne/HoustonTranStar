using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class Id
    {
        [XmlText]
        public string Value { get; set; }
    }
}