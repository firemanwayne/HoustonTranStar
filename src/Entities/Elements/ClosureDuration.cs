﻿using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class ClosureDuration
    {
        [XmlText]
        public string Value { get; set; }
    }
}