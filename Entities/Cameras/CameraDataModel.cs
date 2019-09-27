using HoustonTranStar.Entities.Elements;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Cameras
{
    [Serializable]
    [XmlRoot("CAMERAS")]
    public class CameraDataModel
    {
        [XmlElement("CAMERA")]
        public List<Camera> ListCameras { get; set; }
    }

    [Serializable]
    public class Camera
    {
        [XmlElement("ID")]
        public Id IdElement { get; set; }

        [XmlElement("NAME")]
        public Name NameElement { get; set; }

        [XmlElement("ROADWAY")]
        public RoadwayName RoadWayNameElement { get; set; }

        [XmlElement("LOCATION")]
        public Location LocationElement { get; set; }

        [XmlElement("LATITUDE")]
        public Latitude LatitudeElement { get; set; }

        [XmlElement("LONGITUDE")]
        public Longitude LongitudeElement { get; set; }

        [XmlElement("DIRECTION")]
        public Direction DirectionElement { get; set; }

        [XmlElement("PATH")]
        public Path PathElement { get; set; }

        [XmlElement("VALID_IMAGE")]
        public ValidImage ValidImageElement { get; set; }
    }
}