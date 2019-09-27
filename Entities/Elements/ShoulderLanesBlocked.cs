using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class ShoulderLanesBlocked
    {
        [XmlText]
        public string Value { get; set; }
    }
}