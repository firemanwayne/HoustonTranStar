using HoustonTranStar.Entities.Elements;
using System.Xml.Serialization;

namespace HoustonTranStar.Entities
{
    public class Camera
    {
        [XmlElement("ID")]
        public Id Id { get; set; }

        [XmlElement("NAME")]
        public Name Name { get; set; }

        [XmlElement("ROADWAY")]
        public RoadwayName RoadWayName { get; set; }

        [XmlElement("LOCATION")]
        public Location Location { get; set; }

        [XmlElement("LATITUDE")]
        public Latitude Latitude { get; set; }

        [XmlElement("LONGITUDE")]
        public Longitude Longitude { get; set; }

        [XmlElement("DIRECTION")]
        public Direction Direction { get; set; }

        [XmlElement("PATH")]
        public Path Path { get; set; }

        [XmlElement("VALID_IMAGE")]
        public ValidImage ValidImage { get; set; }
    }
}