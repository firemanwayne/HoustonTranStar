using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class CrossStreetQual
    {
        [XmlText]
        public string Value { get; set; }
    }
}