﻿using Catharsium.Calendar.Core.Entities.Models.Scheduler;
using Catharsium.External.GoogleCalendar.Client.Models;
using System;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Logic.Interfaces;

public interface IAppointmentGenerator
{
    Interval Interval { get; }

    Task<Event[]> GenerateFor(DateTime fromDate, DateTime toDate, Appointment appointment);
}