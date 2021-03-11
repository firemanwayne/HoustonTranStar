using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class CrossStreet
    {
        [XmlText]
        public string Value { get; set; }
    }
}