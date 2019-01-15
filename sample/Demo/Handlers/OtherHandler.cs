using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcCommands;

namespace Demo
{
    public class OtherHandler : ICommandHandler<OtherCommand>
    {
        public async Task<IActionResult> ExecuteCommand(OtherCommand commandModel, ControllerBase sender)
        {
            await Task.Delay(100);
            var link = sender.Url.RouteUrl("Sample", new {id = "sample-id"});
            return sender.Ok(link);
        }
    }
}