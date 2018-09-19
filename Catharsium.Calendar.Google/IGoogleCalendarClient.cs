﻿using Google.Apis.Calendar.v3.Data;
using System;

namespace Catharsium.Calendar.Google
{
    public interface IGoogleCalendarClient
    {
        Event CreateEvent(string summary, DateTime start, DateTime end);
        Events GetEvents();
    }
}