using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class Status
    {
        [XmlText]
        public string Value { get; set; }
    }
}