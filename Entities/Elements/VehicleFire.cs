using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class VehicleFire
    {
        [XmlText]
        public string Value { get; set; }
    }
}