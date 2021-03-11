using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class LanesAffected
    {
        [XmlText]
        public string Value { get; set; }
    }
}