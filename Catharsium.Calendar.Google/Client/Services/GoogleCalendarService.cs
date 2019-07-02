using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoMapper;
using Catharsium.Calendar.Core.Entities.Interfaces;
using Google.Apis.Calendar.v3;

namespace Catharsium.Calendar.Google.Client.Services
{
    [ExcludeFromCodeCoverage]
    public class GoogleCalendarService : ICalendarService
    {
        private readonly CalendarService calendarService;
        private readonly IMapper mapper;


        public GoogleCalendarService(ICalendarClientFactory clientFactory, IMapper mapper)
        {
            this.calendarService = clientFactory.CreateClient();
            this.mapper = mapper;
        }


        public IEnumerable<Core.Entities.Models.Calendar> GetList()
        {
            var request = this.calendarService.CalendarList.List();
            var result = request.Execute();
            return result.Items.Select(c => this.mapper.Map<Core.Entities.Models.Calendar>(c));
        }


        public Core.Entities.Models.Calendar Get(string calendarId)
        {
            var request = this.calendarService.CalendarList.Get(calendarId);
            var result = request.Execute();
            return this.mapper.Map<Core.Entities.Models.Calendar>(result);
        }
    }
}