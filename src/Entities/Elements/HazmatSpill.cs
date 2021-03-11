using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class HazmatSpill
    {
        [XmlText]
        public string Value { get; set; }
    }
}