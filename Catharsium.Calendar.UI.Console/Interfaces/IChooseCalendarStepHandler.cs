using System.Threading.Tasks;

namespace Catharsium.Calendar.UI.Console.Interfaces
{
    public interface IChooseCalendarStepHandler
    {
        Task<Core.Entities.Models.Calendar> Run();
    }
}