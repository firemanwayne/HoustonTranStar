﻿using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class OriginId
    {
        [XmlText]
        public string Value { get; set; }
    }
}