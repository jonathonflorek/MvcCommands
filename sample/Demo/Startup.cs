using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MvcCommands;

namespace Demo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // tell MvcCommands to setup magic routing of requests to RoutedCommand handlers
            services.AddMvc().AddCommandControllerRouting();

            // manually register a command handler
            services.AddTransient<ICommandHandler<SampleCommand>, SampleHandler>();
            services.AddTransient<ICommandHandler<OtherCommand>, OtherHandler>();

            // manually register the handler's dependencies
            services.AddSingleton(new SampleHandler.SampleHandlerOptions
            {
                DelayMilliseconds = 1000,
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}
