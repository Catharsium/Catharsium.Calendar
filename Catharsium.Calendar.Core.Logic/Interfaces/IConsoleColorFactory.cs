using System;

namespace Catharsium.Calendar.Core.Logic.Interfaces
{
    public interface IConsoleColorFactory
    {
        ConsoleColor GetById(string calendarId, string colorId);
    }
}