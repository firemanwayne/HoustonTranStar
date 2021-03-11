using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class EndLatitude
    {
        [XmlText]
        public string Value { get; set; }
    }
}