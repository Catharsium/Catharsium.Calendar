﻿namespace Catharsium.Calendar.Core.Entities.Models
{
    public class Reminder
    {
        public virtual string ETag { get; set; }
        public virtual int? Minutes { get; set; }
        public virtual string Method { get; set; }
    }
}