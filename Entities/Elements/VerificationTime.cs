using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class VerificationTime
    {
        [XmlText]
        public string Value { get; set; }
    }
}