using System.Collections.Generic;
using System.Xml.Serialization;

namespace HoustonTranStar.Entities
{
    [XmlRoot("INCIDENT_DATA")]
    public class IncidentDTO
    {
        [XmlElement(ElementName = "INCIDENT")]
        public List<Incident> Incidents { get; set; }
    }
}