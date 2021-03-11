using HoustonTranStar.Entities.Elements;
using System.Xml.Serialization;

namespace HoustonTranStar.Entities
{
    public class LaneClosure
    {
        [XmlElement(ElementName = "ID")]
        public Id Id { get; set; }

        [XmlElement(ElementName = "ROADWAY_NAME")]
        public RoadwayName RoadWayNameElement { get; set; }

        [XmlElement(ElementName = "DIRECTION")]
        public Direction DirectionElement { get; set; }

        [XmlElement(ElementName = "BEGIN_CROSS_STREET")]
        public BeginCrossStreet BeginCrossStreetElement { get; set; }

        [XmlElement(ElementName = "BEGIN_LATITUDE")]
        public BeginLatitude BeginLatitudeElement { get; set; }

        [XmlElement(ElementName = "BEGIN_LONGITUDE")]
        public BeginLongitude BeginLongitudeElement { get; set; }

        [XmlElement(ElementName = "END_CROSS_STREET")]
        public EndCrossStreet EndCrossStreetElement { get; set; }

        [XmlElement(ElementName = "END_LATITUDE")]
        public EndLatitude EndLatitudeElement { get; set; }

        [XmlElement(ElementName = "END_LONGITUDE")]
        public EndLongitude EndLongitudeElement { get; set; }

        [XmlElement(ElementName = "CLOSURE_START_DATE")]
        public ClosureStartDate ClosureStartDateElement { get; set; }

        [XmlElement(ElementName = "CLOSURE_END_DATE")]
        public ClosureEndDate ClosureEndDateElement { get; set; }

        [XmlElement(ElementName = "CLOSURE_DESCRIPTION")]
        public ClosureDescription ClosureDescriptionElement { get; set; }

        [XmlElement(ElementName = "COUNTY_NAME")]
        public CountyName CountyNameElement { get; set; }

        [XmlElement(ElementName = "FACILITY_TYPE")]
        public FacilityType FacilityTypeElement { get; set; }

        [XmlElement(ElementName = "CLOSURE_DURATION")]
        public ClosureDuration ClosureDurationElement { get; set; }

        [XmlElement(ElementName = "DURATION_EXCEPTION")]
        public DurationException DurationExceptionElement { get; set; }

        [XmlElement(ElementName = "LANES_AFFECTED")]
        public LanesAffected LanesAffectedElement { get; set; }

        [XmlElement(ElementName = "DETOUR")]
        public Detour DetourElement { get; set; }

        [XmlElement(ElementName = "LOCATION")]
        public Location LocationElement { get; set; }

        [XmlElement(ElementName = "DURATION_DESCRIPTION")]
        public DurationDescription DurationDescriptionElement { get; set; }

        [XmlElement(ElementName = "STATUS")]
        public Status Status { get; set; }
    }
}