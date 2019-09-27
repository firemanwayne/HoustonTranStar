using HoustonTranStar.Entities.Elements;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Incidents
{
    [Serializable]
    [XmlRoot("INCIDENT_DATA")]
    public class IncidentDataModel
    {
        [XmlElement(ElementName = "INCIDENT")]
        public List<Incident> Incidents { get; set; }
    }

    [Serializable]
    public class Incident
    {
        [XmlElement(ElementName = "ID")]
        public Id IdElement { get; set; }

        [XmlElement(ElementName = "ROADWAY_NAME")]
        public RoadwayName RoadWayNameElement { get; set; }

        [XmlElement(ElementName = "DIRECTION")]
        public Direction DirectionElement { get; set; }

        [XmlElement(ElementName = "CROSS_STREET_QUAL")]
        public CrossStreetQual CrossStreetQualElement { get; set; }

        [XmlElement(ElementName = "CROSS_STREET")]
        public CrossStreet CrossStreetElement { get; set; }

        [XmlElement(ElementName = "LATITUDE")]
        public Latitude LatitudeElement { get; set; }

        [XmlElement(ElementName = "LONGITUDE")]
        public Longitude LongitudeElement { get; set; }

        [XmlElement(ElementName = "STATUS")]
        public Status StatusElement { get; set; }

        [XmlElement(ElementName = "HAZMAT_SPILL")]
        public HazmatSpill HazmatSpillElement { get; set; }

        [XmlElement(ElementName = "HEAVY_TRUCK")]
        public HeavyTruck HeavyTruckElement { get; set; }

        [XmlElement(ElementName = "HIGH_WATER")]
        public HighWater HighWaterElement { get; set; }

        [XmlElement(ElementName = "ICE_ON_ROADWAY")]
        public IceOnRoadway IceOnRoadwayElement { get; set; }

        [XmlElement(ElementName = "LOST_LOAD")]
        public LostLoad LostLoadElement { get; set; }

        [XmlElement(ElementName = "ROAD_DEBRIS")]
        public RoadDebris RoadDebrisElement { get; set; }

        [XmlElement(ElementName = "STALL")]
        public Stall StallElement { get; set; }

        [XmlElement(ElementName = "VEHICLE_FIRE")]
        public VehicleFire VehicleFireElement { get; set; }

        [XmlElement(ElementName = "OTHER")]
        public Other OtherElement { get; set; }

        [XmlElement(ElementName = "BUS")]
        public Bus BusElement { get; set; }

        [XmlElement(ElementName = "ACCIDENT")]
        public Accident AccidentElement { get; set; }

        [XmlElement(ElementName = "CONSTRUCTION")]
        public Construction ConstructionElement { get; set; }

        [XmlElement(ElementName = "VEHICLES_INVOLVED")]
        public VehiclesInvolved VehiclesInvolvedElement { get; set; }

        [XmlElement(ElementName = "LANES_AFFECTED")]
        public LanesAffected LanesAffectedElement { get; set; }

        [XmlElement(ElementName = "MAINLANES_BLOCKED")]
        public MainLanesBlocked MainLanesBlockedElement { get; set; }

        [XmlElement(ElementName = "FRONTAGE_LANES_BLOCKED")]
        public FrontageLanesBlocked FrontageLanesBlockedElement { get; set; }

        [XmlElement(ElementName = "RAMP_LANES_BLOCKED")]
        public RampLanesBlocked RampLanesBlockedElement { get; set; }

        [XmlElement(ElementName = "HOV_LANES_BLOCKED")]
        public HOVLanesBlocked HOVLanesBlockedElement { get; set; }

        [XmlElement(ElementName = "SHOULDER_LANES_BLOCKED")]
        public ShoulderLanesBlocked ShoulderLanesBlockedElement { get; set; }

        [XmlElement(ElementName = "OPPOSING_MAINLANES_BLOCKED")]
        public OpposingMainLanesBlocked OpposingMainLanesBlockedElement { get; set; }

        [XmlElement(ElementName = "OPPOSING_SHOULDER_LANES_BLOCKED")]
        public OpposingShoulderLanesBlocked OpposingShoulderLanesBlockedElement { get; set; }

        [XmlElement(ElementName = "DETECTION_TIME")]
        public DetectionTime DetectionTimeElement { get; set; }

        [XmlElement(ElementName = "VERIFICATION_TIME")]
        public VerificationTime VerificationTimeElement { get; set; }

        [XmlElement(ElementName = "MOVED_TIME")]
        public MovedTime MovedTimeElement { get; set; }

        [XmlElement(ElementName = "CLEARED_TIME")]
        public ClearTime ClearTimeElement { get; set; }

        [XmlElement(ElementName = "LANE_SUMMARY")]
        public LaneSummary LaneSummaryElement { get; set; }
    }
}