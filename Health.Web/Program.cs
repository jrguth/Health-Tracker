using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Health.Web.Data;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Health.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddEventSourceLogger();
                });

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var contextFactory = services.GetRequiredService<IDbContextFactory<HoopDBContext>>();
                    DbInitializer.Initialize(contextFactory.CreateDbContext(), services.GetRequiredService<ILogger<DbInitializer>>());
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        private class DbInitializer
        {
            public static void Initialize(HoopDBContext context, ILogger<DbInitializer> logger)
            {
                bool exists = context.Database.EnsureCreated();
                if (exists)
                    logger.LogInformation("Database already exists, no action taken");
                logger.LogInformation("Migrating...");
                context.Database.Migrate();
            }
        }
    }
}
