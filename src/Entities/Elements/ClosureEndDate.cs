using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class ClosureEndDate
    {
        [XmlText]
        public string Value { get; set; }
    }
}