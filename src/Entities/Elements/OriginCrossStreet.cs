using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class OriginCrossStreet
    {
        [XmlText]
        public string Value { get; set; }
    }
}