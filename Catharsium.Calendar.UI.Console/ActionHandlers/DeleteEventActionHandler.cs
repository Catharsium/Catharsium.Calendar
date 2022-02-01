using Catharsium.Util.IO.Console.ActionHandlers.Base;
using Catharsium.Util.IO.Console.Interfaces;
using System;
using System.Threading.Tasks;
namespace Catharsium.Calendar.UI.Console.ActionHandlers;

public class DeleteEventActionHandler : BaseActionHandler
{
    public string FriendlyName => "Delete event";


    public DeleteEventActionHandler(IConsole console) : base(console, "Delete event")
    { }


    public override async Task Run()
    {
        throw new NotImplementedException();
    }
}