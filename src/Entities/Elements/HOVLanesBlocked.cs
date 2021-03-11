using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class HOVLanesBlocked
    {
        [XmlText]
        public string Value { get; set; }
    }
}