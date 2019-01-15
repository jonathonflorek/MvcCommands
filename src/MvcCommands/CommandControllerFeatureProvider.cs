using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MvcCommands
{
    public class CommandControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var controllers =
                from part in parts
                let assemblyPart = part as AssemblyPart
                where assemblyPart != null
                from type in assemblyPart.Types
                let isRoutedCommandModel = type.GetCustomAttributes<RoutedCommandAttribute>().Any()
                where isRoutedCommandModel
                select typeof(CommandController<>).MakeGenericType(type).GetTypeInfo();
            
            foreach(var controller in controllers)
            {
                feature.Controllers.Add(controller);
            }
        }
    }
}