﻿using System;

namespace Catharsium.Calendar.Core.Entities.Models
{
    public class Date
    {
        public string ETag { get; set; }
        public bool HasTime { get; set; }
        public DateTime Value { get; set; }
        public string TimeZone { get; set; }
    }
}