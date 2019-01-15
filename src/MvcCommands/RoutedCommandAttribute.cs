using System;
using System.Collections.Generic;

namespace MvcCommands
{
    [AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class RoutedCommandAttribute : Attribute
    {
        public RoutedCommandAttribute(String template, params String[] methods)
        {
            Template = template ?? throw new ArgumentNullException(nameof(template));
            Methods = methods ?? throw new ArgumentNullException(nameof(methods));
        }

        public String Template { get; }

        public IEnumerable<String> Methods { get; }

        public String Name { get; set; }
    }
}