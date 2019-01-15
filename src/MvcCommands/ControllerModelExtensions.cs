using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Linq;

namespace MvcCommands
{
    public static class ControllerModelExtensions
    {
        public static Boolean IsCommandController(this ControllerModel controller, out Type commandModelType)
        {
            var isCommandController = controller.ControllerType.IsGenericType &&
                controller.ControllerType.GetGenericTypeDefinition() == typeof(CommandController<>);
            commandModelType = isCommandController ?
                controller.ControllerType.GenericTypeArguments.Single() :
                null;
            return isCommandController;
        }
    }
}