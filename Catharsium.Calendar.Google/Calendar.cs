using System;
using System.Collections.Generic;
using Catharsium.Calendar.Google.Core.Entities.Interfaces;
using Catharsium.Calendar.Google.Core.Entities.Models;

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