using System.Threading.Tasks;

namespace Catharsium.Calendar.UI.Console.Interfaces;

public interface IChooseCalendarStepHandler
{
    Task<External.GoogleCalendar.Client.Models.Calendar> Run();
}