using System.Collections.Generic;
using System.Xml.Serialization;

namespace HoustonTranStar.Entities
{
    [XmlRoot("CAMERAS")]
    public class CameraDTO
    {
        [XmlElement("CAMERA")]
        public List<Camera> Cameras { get; set; }
    }
}