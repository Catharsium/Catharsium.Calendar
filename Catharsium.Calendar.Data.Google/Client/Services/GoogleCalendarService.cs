using AutoMapper;
using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Data.Google.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Calendar.Data.Google.Client.Services
{
    [ExcludeFromCodeCoverage]
    public class GoogleCalendarService : ICalendarService
    {
        private readonly ICalendarClientFactory clientFactory;
        private readonly IMapper mapper;


        public GoogleCalendarService(ICalendarClientFactory clientFactory, IMapper mapper)
        {
            this.clientFactory = clientFactory;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<Core.Entities.Models.Calendar>> GetList()
        {
            var calendarService = this.clientFactory.Get();
            var request = calendarService.CalendarList.List();
            var result = await Task.Run(() => request.Execute());
            return result.Items.Select(c => this.mapper.Map<Core.Entities.Models.Calendar>(c));
        }


        public async Task<Core.Entities.Models.Calendar> Get(string calendarId)
        {
            var calendarService = this.clientFactory.Get();
            var request = calendarService.CalendarList.Get(calendarId);
            var result = await Task.Run(() => request.Execute());
            return this.mapper.Map<Core.Entities.Models.Calendar>(result);
        }
    }
}