using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
            // configuring database access service
            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));

            //services.AddDbContext<AppDbContext>();

            // AddMvc calls AddMvcCore method which calls MvcCore services
            services.AddMvc().AddXmlSerializerFormatters();

            // switches from in-memory list to sql database service
            //services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
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
                //app.UseExceptionHandler("/Error - Staging");
                //app.UseStatusCodePagesWithRedirects("/Error/{0}");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
            else if (env.IsProduction())
            {
                Console.WriteLine("You're using production environment!");
                app.UseExceptionHandler("/Error");
                //app.UseStatusCodePagesWithRedirects("/Error/{0}");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
            else if (env.IsEnvironment("uat"))
            {
                // this is for custom environment
                Console.WriteLine("You're using a custom environment - uat");
                //app.UseExceptionHandler("/Error - uat");
                //app.UseStatusCodePagesWithRedirects("/Error/{0}");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
            else if (env.IsEnvironment("test"))
            {
                // this is for custom environment
                Console.WriteLine("You're using a custom environment - test");
                //app.UseExceptionHandler("/Error - test");
                //app.UseStatusCodePagesWithRedirects("/Error/{0}");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
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

            //app.UseMvcWithDefaultRoute();

            // using conventional routing (if using route attributes - then comment this part out or you can use both for more flexibility)
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hosting Environment " + env.EnvironmentName);
            //});

        }
    }
}
