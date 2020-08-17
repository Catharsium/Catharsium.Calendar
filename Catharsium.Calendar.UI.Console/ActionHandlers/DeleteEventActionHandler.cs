using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.Threading.Tasks;

namespace Catharsium.Calendar.UI.Console.ActionHandlers
{
    public class DeleteEventActionHandler : IActionHandler
    {
        public string FriendlyName => "Delete event";


        Task IActionHandler.Run()
        {
            throw new NotImplementedException();
        }
    }
}