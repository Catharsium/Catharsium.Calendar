using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Calendar.Core.Entities.Models.Scheduler;
using System;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Core.Logic.Interfaces
{
    public interface ITemplateScheduler
    {
        Task<Event[]> Schedule(DateTime date, Template template);
    }
}