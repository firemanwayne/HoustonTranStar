using HoustonTranStar.Entities.Elements;
using System.Xml.Serialization;

namespace HoustonTranStar.Entities
{
    public class SpeedTravelTimeRoadWaySegment
    {
        [XmlElement("ID1")]
        public OriginId OriginId { get; set; }

        [XmlElement("ID2")]
        public DestinationId DestinationId { get; set; }

        [XmlElement("SPD")]
        public Speed Speed { get; set; }

        [XmlElement("TT")]
        public TravelTime TravelTime { get; set; }

        [XmlElement("TM")]
        public TimeStamp TimeStamp { get; set; }
    }
}