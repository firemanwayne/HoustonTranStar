using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class DestinationCrossStreet
    {
        [XmlText]
        public string Value { get; set; }
    }
}