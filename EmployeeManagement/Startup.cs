using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace EmployeeManagement
{
    public class Startup
    {
        // dependency injection 
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // AddMvc calls AddMvcCore method which calls MvcCore services
            services.AddMvc().AddXmlSerializerFormatters();  
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                Console.WriteLine("You're using develop environment!");
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsStaging())
            {
                Console.WriteLine("You're using staging environment!");
                app.UseExceptionHandler("/Error - Staging");
            }
            else if (env.IsProduction())
            {
                Console.WriteLine("You're using production environment!");
                app.UseExceptionHandler("/Error - Production");
            }
            else if (env.IsEnvironment("UAT"))
            {
                // this is for custom environment
                Console.WriteLine("You're using a custom environment - UAT");
                app.UseExceptionHandler("/Error - UAT");
            }

            // uses lambda expressions, extension methods, delegates, anonymous methods
            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW1: Incoming request");
            //    await next();
            //    logger.LogInformation("MW1: outgoing response");
            //});

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW2: Incoming request");
            //    await next();
            //    logger.LogInformation("MW2: outgoing response");
            //});

            // overloading default files method to default another .html file
            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("foo.html");

            // overloading file server method
            //FileServerOptions fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");

            // order of middleware is important
            //app.UseDefaultFiles(defaultFilesOptions);
            //app.UseStaticFiles();
            //app.UseFileServer(fileServerOptions);
             
            // Order by which middleware is called
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hosting Environment " + env.EnvironmentName);
            });

        }
    }
}
