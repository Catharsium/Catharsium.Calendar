using System.Threading.Tasks;

namespace Catharsium.Calendar.UI.Console.Interfaces
{
    public interface IChooseCalendarStepHandler
    {
        Task<Clients.GoogleCalendar.Models.Calendar> Run();
    }
}