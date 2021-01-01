using Catharsium.Calendar.Core.Entities.Models;
using Catharsium.Util.IO.Console.Interfaces;
using Catharsium.Util.IO.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Catharsium.Calendar.UI.Console.ActionHandlers
{
    public class LoadActionHandler : IActionHandler
    {
        private readonly IConsole console;
        private readonly IJsonFileRepository<Event> jsonFileRepository;


        public string FriendlyName => "Load action";


        public LoadActionHandler(IConsole console, IJsonFileRepository<Event> jsonFileRepository)
        {
            this.console = console;
            this.jsonFileRepository = jsonFileRepository;
        }


        public async Task Run()
        {
            var events = (await this.jsonFileRepository.LoadAll()).ToList();
            var duration = TotalTimeCalculator.CalculateTotalTime(events);
            this.console.WriteLine($"{events.Count} events found for a total of {duration} duration.");
            this.console.WriteLine();
        }
    }
}