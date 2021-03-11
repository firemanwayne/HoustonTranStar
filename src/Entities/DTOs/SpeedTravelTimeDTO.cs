using System.Collections.Generic;
using System.Xml.Serialization;

namespace HoustonTranStar.Entities
{
    [XmlRoot("SPEED_DATA")]
    public class SpeedTravelTimeDTO
    {
        [XmlElement(ElementName = "SEG")]
        public List<SpeedTravelTimeRoadWaySegment> Segments { get; set; }
    }
}