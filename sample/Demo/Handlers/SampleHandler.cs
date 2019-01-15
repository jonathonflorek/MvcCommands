using Microsoft.AspNetCore.Mvc;
using MvcCommands;
using System;
using System.Threading.Tasks;

namespace Demo
{
    public class SampleHandler : ICommandHandler<SampleCommand>
    {
        public SampleHandler(SampleHandlerOptions options)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public SampleHandlerOptions Options { get; }

        public async Task<IActionResult> ExecuteCommand(SampleCommand commandModel, ControllerBase sender)
        {
            await Task.Delay(Options.DelayMilliseconds);
            return sender.Ok(commandModel);
        }

        public class SampleHandlerOptions
        {
            public Int32 DelayMilliseconds { get; set; }
        }
    }
}