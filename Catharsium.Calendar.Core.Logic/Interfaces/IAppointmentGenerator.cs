using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Entities.Models.Scheduler;
using System;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Logic.Interfaces
{
    public interface IAppointmentGenerator
    {
        Interval Interval { get; }

        Task<Event[]> GenerateFor(DateTime fromDate, DateTime toDate, Appointment appointment);
    }
}