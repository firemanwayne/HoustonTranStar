﻿using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class ClosureStartDate
    {
        [XmlText]
        public string Value { get; set; }
    }
}