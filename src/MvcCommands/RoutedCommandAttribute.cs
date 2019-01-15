using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcCommands
{
    /// <summary>
    /// Specifies that a type is a routed command.
    /// </summary>
    [AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class RoutedCommandAttribute : Attribute
    {
        /// <summary>
        /// Creates a new <see cref="RoutedCommandAttribute"/> with the given
        /// route template and http methods.
        /// </summary>
        /// <param name="template">
        /// The route template. May not be null.
        /// </param>
        /// <param name="template">
        /// The route's accepted http methods.
        /// </param>
        public RoutedCommandAttribute(String template, params String[] httpMethods)
        {
            if (httpMethods == null)
            {
                throw new ArgumentNullException(nameof(httpMethods));
            }

            Template = template ?? throw new ArgumentNullException(nameof(template));
            HttpMethods = httpMethods.ToList();
        }

        /// <summary>
        /// Gets the route template.
        /// </summary>
        public String Template { get; }

        /// <summary>
        /// Gets an enumerable containing the http methods this
        /// route accepts.
        /// </summary>
        public IEnumerable<String> HttpMethods { get; }

        /// <summary>
        /// Gets or sets the route name.
        /// </summary>
        public String RouteName { get; set; }

        /// <summary>
        /// Gets or sets the route order.
        /// </summary>
        public Int32 Order { get; set; }
    }
}