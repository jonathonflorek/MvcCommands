using System;
using System.Collections.Generic;

namespace MvcCommands
{
    [AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class RoutedCommandAttribute : Attribute
    {
        public RoutedCommandAttribute(String route, params String[] methods)
        {
            Route = route ?? throw new ArgumentNullException(nameof(route));
            Methods = methods ?? throw new ArgumentNullException(nameof(methods));
        }

        public String Route { get; }

        public IEnumerable<String> Methods { get; }
    }
}