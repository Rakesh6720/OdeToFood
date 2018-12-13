using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OdeToFood
{
    public class Startup
    {
        // This method registers services that ASP .NET Core can inject into other components
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env,
                              IGreeter greeter,
                              ILogger<Startup> logger)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.Use(next => // this function called only once by framework once ready to setup the pipeline
            {
                return async context => // this is the Middleware, which executes once for each HTTP Request that reaches this Mmiddleware
                {
                    logger.LogInformation("Request incoming");
                    if (context.Request.Path.StartsWithSegments("/mym"))
                    {
                        await context.Response.WriteAsync("Hit!!");
                        logger.LogInformation("Request Handled");
                    }
                    else
                    {
                        await next(context);
                        logger.LogInformation("Response outgoing");
                    }
                };
            });
            
            // This is a simple piece of 'Middleware' that will respond to every request by default
            app.UseWelcomePage(new WelcomePageOptions
            {
                Path = "/wp"
            });

            app.Run(async (context) =>
            {
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}
