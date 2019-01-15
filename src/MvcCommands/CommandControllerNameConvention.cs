using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;

namespace MvcCommands
{
    /// <summary>
    /// Applies controller names to command controllers based on the name of
    /// their routed command model type
    /// </summary>
    /// <remarks>
    /// The name of the controller is configured to be the name of the routed 
    /// command model type. If the type's name ends in the string 'Command',
    /// the 'Command' ending is omitted. Routed command names 'Sample' and
    /// 'SampleCommand' will be handled by a controller with the name 'Sample'.
    /// </remarks>
    public class CommandControllerNameConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (!controller.TryGetRoutedCommand(out var commandModelType))
            {
                return;
            }

            var typeName = commandModelType.Name;
            var commandName = typeName.EndsWith(CommandPostfix) ?
                typeName.Substring(0, typeName.Length - CommandPostfix.Length) :
                typeName;

            controller.ControllerName = commandName;
        }

        private const String CommandPostfix = "Command";
    }
}