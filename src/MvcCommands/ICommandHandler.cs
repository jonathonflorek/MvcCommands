using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MvcCommands
{
    /// <summary>
    /// Defines a routed command handler.
    /// </summary>
    /// <typeparam name="TCommandModel">
    /// The type of the routed command. This type should have at least one <see cref="RoutedCommandAttribute"/> attribute.
    /// </typeparam>
    /// <remarks>
    /// <see cref="CommandController"/> depends on an instance of this interface
    /// to process routed commands. An implementation of this interface is required
    /// for each routed command type.
    /// </remarks>
    public interface ICommandHandler<TCommandModel>
    {
        /// <summary>
        /// Executes a routed command.
        /// </summary>
        /// <param name="commandModel">
        /// The routed command instance.
        /// </param>
        /// <param name="sender">
        /// The <see cref="ControllerBase"/> instance that originally recieved the routed command.
        /// </param>
        Task<IActionResult> ExecuteCommand(TCommandModel commandModel, ControllerBase sender);
    }
}