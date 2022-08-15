using Catharsium.Calendar.Core.Logic._Configuration;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Util.Enums;
using System;
using System.Linq;

namespace Catharsium.Calendar.Core.Logic.Presentation;

public class ConsoleColorFactory : IConsoleColorFactory
{
    private readonly CalendarCoreLogicSettings configuration;


    public ConsoleColorFactory(CalendarCoreLogicSettings configuration)
    {
        this.configuration = configuration;
    }


    public ConsoleColor GetById(string calendarId, string colorId)
    {
        var calendarColor = this.configuration.CalendarColors.FirstOrDefault(c => c.Id == colorId);
        return calendarColor?.ConsoleColor.ParseEnum<ConsoleColor>() ?? ConsoleColor.White;
    }
}