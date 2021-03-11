using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class EndCrossStreet
    {
        [XmlText]
        public string Value { get; set; }
    }
}