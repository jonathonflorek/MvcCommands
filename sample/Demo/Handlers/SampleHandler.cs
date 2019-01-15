using Microsoft.AspNetCore.Mvc;
using MvcCommands;
using System;
using System.Threading.Tasks;

namespace Demo
{
    public class SampleHandler : ICommandHandler<SampleCommand>
    {
        public async Task<IActionResult> ExecuteCommand(SampleCommand commandModel, ControllerBase sender)
        {
            await Task.Delay(1000);
            return sender.Ok(commandModel);
        }
    }
}