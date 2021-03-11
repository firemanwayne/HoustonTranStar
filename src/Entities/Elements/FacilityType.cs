using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class FacilityType
    {
        [XmlText]
        public string Value { get; set; }
    }
}