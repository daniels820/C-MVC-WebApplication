using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using DAL.EF.EntityFrameworkContext;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();
            var connection = @"Data Source=tcp:tky4ecqv9m.database.windows.net,1433;Initial Catalog=AteraDevServerForInterviews;Integrated Security=False;User ID=TestUser69326@tky4ecqv9m;Password=Password69326;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var connectionString = Configuration["DbContextSettings:ConnectionString"];
            services.AddDbContext<AteraDevServerForInterviewsContext>(options => options.UseSqlServer(connectionString));


             
         //   var connection = @"Data Source=tcp:tky4ecqv9m.database.windows.net,1433;Initial Catalog=AteraDevServerForInterviews;Integrated Security=False;User ID=TestUser69326@tky4ecqv9m;Password=********;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            // services.AddDbContext<TablesContext>(options => options.UseSqlServer(connection));

            Debug.WriteLine("here-startup");
          //  Server = tcp:tky4ecqv9m.database.windows.net,1433; Database = AteraDevServerForInterviews; User ID = TestUser69326@tky4ecqv9m; Password = Password69326; Trusted_Connection = False; Encrypt = True; Connection Timeout = 30;

        }
            
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Login}/{id?}");
            });
        }
    }
}
