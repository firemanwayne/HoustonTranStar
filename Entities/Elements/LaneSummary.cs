using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class LaneSummary
    {
        [XmlText]
        public string Value { get; set; }
    }
}