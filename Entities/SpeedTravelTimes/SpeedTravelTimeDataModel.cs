using HoustonTranStar.Entities.Elements;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace HoustonTranStar.Entities.SpeedTravelTimes
{
    [Serializable()]
    [XmlRoot("SPEED_DATA")]
    public class SpeedTravelTimeDataModel
    {
        [XmlElement(ElementName = "SEG")]
        public List<SpeedTravelTimeRoadWaySegment> Segments { get; set; }
    }

    [Serializable()]
    public class SpeedTravelTimeRoadWaySegment
    {
        [XmlElement("ID1")]
        public OriginId OriginIdElement { get; set; }

        [XmlElement("ID2")]
        public DestinationId DestinationIdElement { get; set; }

        [XmlElement("SPD")]
        public Speed SpeedElement { get; set; }

        [XmlElement("TT")]
        public TravelTime TravelTimeElement { get; set; }

        [XmlElement("TM")]
        public TimeStamp TimeStampElement { get; set; }
    }
}