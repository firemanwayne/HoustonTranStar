using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class DestinationFacilityType
    {
        [XmlText]
        public string Value { get; set; }
    }
}