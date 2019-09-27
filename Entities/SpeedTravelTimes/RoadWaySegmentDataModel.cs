using HoustonTranStar.Entities.Elements;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace HoustonTranStar.Entities.SpeedTravelTimes
{
    [Serializable]
    [XmlRoot("SPEED_SEGMENTS")]
    public class RoadWaySegmentDataModel
    {
        [XmlElement(ElementName = "SEG")]
        public List<RoadWaySegment> Segments { get; set; }
    }

    [Serializable]
    public class RoadWaySegment
    {
        [XmlElement(ElementName = "ORG_ROAD")]
        public OriginRoad OriginRoadElement { get; set; }

        [XmlElement(ElementName = "ORG_DIR")]
        public OriginDirection OriginDirectionElement { get; set; }

        [XmlElement(ElementName = "ORG_FAC")]
        public OriginFacilityType OriginFacilityTypeElement { get; set; }

        [XmlElement(ElementName = "ORG_CS")]
        public OriginCrossStreet OriginCrossStreetElement { get; set; }

        [XmlElement(ElementName = "ORG_ID")]
        public OriginId OriginIdElement { get; set; }

        [XmlElement(ElementName = "DEST_ROAD")]
        public DestinationRoad DestinationRoadElement { get; set; }

        [XmlElement(ElementName = "DEST_DIR")]
        public DestinationDirection DestinationDirectionElement { get; set; }

        [XmlElement(ElementName = "DEST_FAC")]
        public DestinationFacilityType DestinationFacilityTypeElement { get; set; }

        [XmlElement(ElementName = "DEST_CS")]
        public DestinationCrossStreet DestinationCrossStreetElement { get; set; }

        [XmlElement(ElementName = "DEST_ID")]
        public DestinationId DestinationIdElement { get; set; }

        [XmlElement(ElementName = "LEN")]
        public Length LengthElement { get; set; }
    }
}