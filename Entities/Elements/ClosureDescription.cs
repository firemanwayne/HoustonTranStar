﻿using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class ClosureDescription
    {
        [XmlText]
        public string Value { get; set; }
    }
}