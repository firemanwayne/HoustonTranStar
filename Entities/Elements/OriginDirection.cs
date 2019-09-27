using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class OriginDirection
    {
        [XmlText]
        public string Value { get; set; }
    }
}