using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Internal;
using System;
using System.Linq;
using System.Reflection;

namespace MvcCommands
{
    public class CommandControllerRouteConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (!controller.IsCommandController(out var commandModelType))
            {
                return;
            }

            var action = controller.Actions.Single();
            var actionSelectors = 
                from routedCommandAttribute in commandModelType.GetCustomAttributes<RoutedCommandAttribute>()
                select new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel
                    {
                        Template = routedCommandAttribute.Template,
                        Name = routedCommandAttribute.RouteName,
                    },
                    ActionConstraints = 
                    {
                        new HttpMethodActionConstraint(routedCommandAttribute.Methods),
                    },
                };
            
            var nonAttributeSelectors = action.Selectors.Where(x => x.AttributeRouteModel == null).ToList();
            foreach(var selector in nonAttributeSelectors)
            {
                action.Selectors.Remove(selector);
            }

            foreach(var selector in actionSelectors)
            {
                action.Selectors.Add(selector);
            }
        }
    }
}