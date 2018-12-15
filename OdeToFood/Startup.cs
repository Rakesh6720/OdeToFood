using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFood.Data;
using OdeToFood.Services;

namespace OdeToFood
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method registers services that ASP .NET Core can inject into other components
        public void ConfigureServices(IServiceCollection services)
        {
            // register your home-made services
            services.AddSingleton<IGreeter, Greeter>();
            services.AddDbContext < OdeToFoodDbContext >(
                options => options.UseSqlServer(_configuration.GetConnectionString("OdeToFood")));
            // typicall you want AddScroped for a data access component
            services.AddScoped<IRestaurantData, SqlRestaurantData>();
            // must make sure to register services required by MVC
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env,
                              IGreeter greeter,
                              ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            // this is the middleware required by MVC
            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                
                var greeting = greeter.GetMessageOfTheDay();
                
                await context.Response.WriteAsync($"Not found");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // /Home/Index
            routeBuilder.MapRoute("Default",
                "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
