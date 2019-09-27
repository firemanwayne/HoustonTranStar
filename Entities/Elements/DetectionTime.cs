using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class DetectionTime
    {
        [XmlText]
        public string Value { get; set; }
    }
}