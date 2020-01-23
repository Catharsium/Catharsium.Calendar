using Catharsium.Calendar.Core.Logic._Configuration;
using Catharsium.Calendar.Core.Logic.Interfaces;
using Catharsium.Util.Enums;
using System;
using System.Linq;

namespace Catharsium.Calendar.Core.Logic.Presentation
{
    public class ConsoleColorFactory : IConsoleColorFactory
    {
        private readonly CalendarCoreLogicConfiguration configuration;


        public ConsoleColorFactory(CalendarCoreLogicConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public ConsoleColor GetById(string calendarId, string colorId)
        {
            var calendarSettings = this.configuration.CalendarSettings.FirstOrDefault(c => c.CalendarId == calendarId);
            var calendarColor = calendarSettings?.CalendarColors.FirstOrDefault(c => c.Id == colorId);
            return calendarColor?.ConsoleColor.ParseEnum<ConsoleColor>() ?? ConsoleColor.White;
        }
    }
}