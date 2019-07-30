using AutoMapper;
using Catharsium.Calendar.Core.Entities.Interfaces.Services;
using Catharsium.Calendar.Google.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Catharsium.Calendar.Google.Client.Services
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


        public IEnumerable<Core.Entities.Models.Calendar> GetList()
        {
            var calendarService = this.clientFactory.Get();
            var request = calendarService.CalendarList.List();
            var result = request.Execute();
            return result.Items.Select(c => this.mapper.Map<Core.Entities.Models.Calendar>(c));
        }


        public Core.Entities.Models.Calendar Get(string calendarId)
        {
            var calendarService = this.clientFactory.Get();
            var request = calendarService.CalendarList.Get(calendarId);
            var result = request.Execute();
            return this.mapper.Map<Core.Entities.Models.Calendar>(result);
        }
    }
}