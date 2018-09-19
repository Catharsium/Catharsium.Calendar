using Catharsium.Calendar.Google.Core.Entities;
using Catharsium.Calendar.Google.Core.Entities.Models;
using System;
using System.Collections.Generic;

namespace Catharsium.Calendar.Google
{
    public class Calendar : ICalendar
    {
        public CalendarEvent CreateEvent()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<CalendarEvent> GetEvents()
        {
            throw new NotImplementedException();
        }
    }
}