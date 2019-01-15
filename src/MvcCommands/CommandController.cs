using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MvcCommands
{
    public sealed class CommandController<TCommandModel> : ControllerBase
    {
        public CommandController(ICommandHandler<TCommandModel> commandHandler)
        {
            CommandHandler = commandHandler ?? throw new System.ArgumentNullException(nameof(commandHandler));
        }

        public ICommandHandler<TCommandModel> CommandHandler { get; }

        public Task<IActionResult> Index(TCommandModel commandModel)
        {
            return CommandHandler.ExecuteCommand(commandModel, this);
        }
    }
}