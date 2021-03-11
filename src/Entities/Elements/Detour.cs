using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class Detour
    {
        [XmlText]
        public string Value { get; set; }
    }
}