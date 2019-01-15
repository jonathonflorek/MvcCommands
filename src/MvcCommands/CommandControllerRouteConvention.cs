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
            if (!IsCommandController(controller.ControllerType))
            {
                return;
            }

            var commandModelType = controller.ControllerType.GenericTypeArguments.Single();
            var action = controller.Actions.Single();
            var selectors = 
                from routedCommandAttribute in commandModelType.GetCustomAttributes<RoutedCommandAttribute>()
                select new SelectorModel
                {
                    AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(routedCommandAttribute.Route)),
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

            foreach(var selector in selectors)
            {
                action.Selectors.Add(selector);
            }
        }

        private Boolean IsCommandController(Type type)
        {
            return type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(CommandController<>);
        }
    }
}