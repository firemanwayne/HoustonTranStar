using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class OpposingShoulderLanesBlocked
    {
        [XmlText]
        public string Value { get; set; }
    }
}