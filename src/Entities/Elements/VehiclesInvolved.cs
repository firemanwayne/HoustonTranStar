using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class VehiclesInvolved
    {
        [XmlText]
        public string Value { get; set; }
    }
}