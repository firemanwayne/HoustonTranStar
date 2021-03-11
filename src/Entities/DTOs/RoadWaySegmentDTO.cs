using System.Collections.Generic;
using System.Xml.Serialization;

namespace HoustonTranStar.Entities
{
    [XmlRoot("SPEED_SEGMENTS")]
    public class RoadWaySegmentDTO
    {
        [XmlElement(ElementName = "SEG")]
        public List<RoadWaySegment> Segments { get; set; }
    }
}