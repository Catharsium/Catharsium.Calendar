﻿using System.Collections.Generic;

namespace Catharsium.Calendar.Core.Entities.Models.Scheduler
{
    public class Template
    {
        public string Name { get; set; }
        public List<Appointment> Appointments { get; set; }


        public override string ToString()
        {
            return this.Name;
        }
    }
}