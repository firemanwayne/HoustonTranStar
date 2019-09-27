using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class DurationException
    {
        [XmlText]
        public string Value { get; set; }
    }
}