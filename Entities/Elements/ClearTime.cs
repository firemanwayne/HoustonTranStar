﻿using System.Xml.Serialization;

namespace HoustonTranStar.Entities.Elements
{
    public class ClearTime
    {
        [XmlText]
        public string Value { get; set; }
    }
}