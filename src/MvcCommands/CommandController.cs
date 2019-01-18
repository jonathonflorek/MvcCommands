using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MvcCommands
{
    /// <summary>
    /// A generic command handling controller
    /// </summary>
    public class CommandController<TCommandModel> : ControllerBase
    {
        public CommandController(ICommandHandler<TCommandModel> commandHandler)
        {
            CommandHandler = commandHandler ?? throw new System.ArgumentNullException(nameof(commandHandler));
        }

        /// <summary>
        /// Gets the CommandHandler for the executing action
        /// </summary>
        public ICommandHandler<TCommandModel> CommandHandler { get; }

        /// <summary>
        /// The action to handle the command
        /// </summary>
        public Task<IActionResult> Index(TCommandModel commandModel)
        {
            return CommandHandler.ExecuteCommand(commandModel, this);
        }
    }
}
