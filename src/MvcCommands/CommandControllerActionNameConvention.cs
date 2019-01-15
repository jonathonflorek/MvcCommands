using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace MvcCommands
{
    public class CommandControllerActionNameConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (!controller.IsCommandController(out var commandModelType))
            {
                return;
            }
        }
    }
}