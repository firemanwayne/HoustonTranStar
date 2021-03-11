using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class Path
    {
        [XmlText]
        public string Value { get; set; }
    }
}