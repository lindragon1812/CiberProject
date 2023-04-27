using Ciber.Context;
using Ciber.DataAccess;
using Ciber.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
                 .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<DapperContext>();
            services.AddControllers();
            services.AddScoped<IRepository, CRepository>();
            services.AddSingleton<IDapperContext, DapperContext>();
            services.AddSingleton<IDataAccess, CDataAccess>();


            services.AddAuthentication("CiberSecurityScheme")
      .AddCookie("CiberSecurityScheme", options =>
      {
          options.AccessDeniedPath = new PathString("/Account/Access");
          options.Cookie = new CookieBuilder
          {
              //Domain = "",
              HttpOnly = true,
              Name = ".Ciber.Security.Cookie",
              Path = "/",
              SameSite = SameSiteMode.Lax,
              SecurePolicy = CookieSecurePolicy.SameAsRequest
          };
          options.Events = new CookieAuthenticationEvents
          {
              OnSignedIn = context =>
              {
                
                  return Task.CompletedTask;
              },
              OnSigningOut = context =>
              {
                
                  return Task.CompletedTask;
              },
              OnValidatePrincipal = context =>
              {
                  return Task.CompletedTask;
              }
          };
          //options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
          options.LoginPath = new PathString("/Account/Login");
          options.ReturnUrlParameter = "RequestPath";
          options.SlidingExpiration = true;
      });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
