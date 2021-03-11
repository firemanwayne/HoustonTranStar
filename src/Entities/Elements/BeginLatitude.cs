using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class BeginLatitude
    {
        [XmlText]
        public string Value { get; set; }
    }
}