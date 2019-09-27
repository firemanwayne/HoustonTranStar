using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class MovedTime
    {
        [XmlText]
        public string Value { get; set; }
    }
}