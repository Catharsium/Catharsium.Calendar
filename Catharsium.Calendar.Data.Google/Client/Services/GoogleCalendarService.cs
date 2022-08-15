using AutoMapper;
using Catharsium.Clients.GoogleCalendar.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Clients.GoogleCalendar.Client.Services;

[ExcludeFromCodeCoverage]
public class GoogleCalendarService : IGoogleCalendarService
{
    private readonly ICalendarClientFactory clientFactory;
    private readonly IMapper mapper;


    public GoogleCalendarService(ICalendarClientFactory clientFactory, IMapper mapper)
    {
        this.clientFactory = clientFactory;
        this.mapper = mapper;
    }


    public async Task<IEnumerable<Models.Calendar>> GetList()
    {
        var calendarService = this.clientFactory.Get();
        var request = calendarService.CalendarList.List();
        var result = await Task.Run(() => request.Execute());
        return result.Items.Select(c => this.mapper.Map<Models.Calendar>(c));
    }


    public async Task<Models.Calendar> Get(string calendarId)
    {
        var calendarService = this.clientFactory.Get();
        var request = calendarService.CalendarList.Get(calendarId);
        var result = await Task.Run(() => request.Execute());
        return this.mapper.Map<Models.Calendar>(result);
    }
}