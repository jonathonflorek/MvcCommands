using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MvcCommands
{
    public interface ICommandHandler<TCommandModel>
    {
        Task<IActionResult> ExecuteCommand(TCommandModel commandModel, Controller sender);
    }
}