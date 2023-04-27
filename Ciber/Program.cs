using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var loggerFactory = LoggerFactory.Create(
           builder => builder
                       // add console as logging target
                       .AddConsole()
                       // add debug output as logging target
                       .AddDebug()
                       // set minimum level to log
                       .SetMinimumLevel(LogLevel.Debug)
       );
            // create a logger
            var logger = loggerFactory.CreateLogger<Program>();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
