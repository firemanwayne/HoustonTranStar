using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class MainLanesBlocked
    {
        [XmlText]
        public string Value { get; set; }
    }
}