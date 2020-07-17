using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Entities.Models.Scheduler;
using System;

namespace Catharsium.Calendar.Core.Logic.Interfaces
{
    public interface IAppointmentScheduler
    {
        Event[] GenerateFor(DateTime fromDate, DateTime toDate, SchedulerSettings settings);
    }
}