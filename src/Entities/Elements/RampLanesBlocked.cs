using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class RampLanesBlocked
    {
        [XmlText]
        public string Value { get; set; }
    }
}