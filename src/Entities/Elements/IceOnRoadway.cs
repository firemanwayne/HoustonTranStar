using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class IceOnRoadway
    {
        [XmlText]
        public string Value { get; set; }
    }
}