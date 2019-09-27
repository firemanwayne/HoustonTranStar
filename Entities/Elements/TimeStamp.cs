using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class TimeStamp
    {
        [XmlText]
        public string Value { get; set; }
    }
}