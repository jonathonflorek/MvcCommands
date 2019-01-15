using Microsoft.Extensions.DependencyInjection;

namespace MvcCommands
{
    /// <summary>
    /// Provides extension methods for <see cref="IMvcBuilder"/> instances.
    /// </summary>
    public static class MvcBuilderExtensions
    {
        /// <summary>
        /// Adds controllers for Routed Commands.
        /// </summary>
        public static IMvcBuilder AddRoutedCommandControllers(this IMvcBuilder builder)
        {
            return builder
                .AddMvcOptions(opts => 
                {
                    opts.Conventions.Add(new CommandControllerRouteConvention());
                    opts.Conventions.Add(new CommandControllerNameConvention());
                })
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Add(new CommandControllerFeatureProvider());
                });
        }
    }
}