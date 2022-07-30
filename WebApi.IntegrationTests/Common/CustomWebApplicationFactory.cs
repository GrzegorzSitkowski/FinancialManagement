using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FinancialManagment.Persistance;
using System;
using FinancialManagment.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Serilog;

namespace WebApi.IntegrationTests.Common
{
    public class CustomWebApplicationFactory<IStartup> : WebApplicationFactory<IStartup> where IStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            try
            {
                builder.ConfigureServices(services =>
                {
                    var serviceProvider = new ServiceCollection()
                        .AddEntityFrameworkInMemoryDatabase()
                        .BuildServiceProvider();

                    services.AddDbContext<FinancialDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("InMemoryDatabase");
                        options.UseInternalServiceProvider(serviceProvider);
                    });

                    services.AddScoped<IFinancialDbContext>(provider => provider.GetService<FinancialDbContext>());

                    var sp = services.BuildServiceProvider();

                    using var scope = sp.CreateScope();
                    var scopedService = scope.ServiceProvider;
                    var context = scopedService.GetRequiredService<FinancialDbContext>();
                    var logger = scopedService.GetRequiredService<ILogger<CustomWebApplicationFactory<IStartup>>>();

                    context.Database.EnsureCreated();

                    try
                    {
                        Utilities.InitilizedDbForTests(context);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error ocured seeding the " +
                            $"database with test messages. Error: {ex.Message}");
                    }
                })
                    .UseSerilog()
                    .UseEnvironment("Test");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
