using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class Speed
    {
        [XmlText]
        public string Value { get; set; }
    }
}