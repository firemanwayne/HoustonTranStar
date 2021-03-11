using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class BeginCrossStreet
    {
        [XmlText]
        public string Value { get; set; }
    }
}