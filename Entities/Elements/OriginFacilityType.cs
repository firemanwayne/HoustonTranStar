﻿using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class OriginFacilityType
    {
        [XmlText]
        public string Value { get; set; }
    }
}