﻿namespace Catharsium.Calendar.Core.Entities.Models
{
    public class Notification
    {
        public virtual string ETag { get; set; }
        public virtual string Type { get; set; }
        public virtual string Method { get; set; }
    }
}