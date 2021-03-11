using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class EndLongitude
    {
        [XmlText]
        public string Value { get; set; }
    }
}