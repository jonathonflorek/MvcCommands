using Microsoft.Extensions.DependencyInjection;

namespace MvcCommands
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddEndpointControllerRouting(this IMvcBuilder builder)
        {
            return builder
                .AddMvcOptions(opts => 
                {
                    opts.Conventions.Add(new CommandControllerRouteConvention());
                })
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Add(new CommandControllerFeatureProvider());
                });
        }
    }
}