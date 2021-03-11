using System.Collections.Generic;
using System.Xml.Serialization;

namespace HoustonTranStar.Entities
{
    [XmlRoot("LANE_CLOSURE_DATA")]
    public class LaneClosureDTO
    {
        [XmlAttribute("TIMESTAMP")]
        public string TimeStamp { get; set; }

        [XmlElement("REPORT_MESSAGE")]
        public string ReportMessage { get; set; }

        [XmlElement(ElementName = "LANE_CLOSURE")]
        public List<LaneClosure> LaneClosures { get; set; }
    }
}