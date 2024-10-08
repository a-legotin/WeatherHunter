﻿using Serilog;
using WeatherHunter.Crawler.RandomSource;

namespace WeatherHunter.Crawler;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostContext, configBuilder) =>
            {
                var settingsFileName = hostContext.HostingEnvironment.IsProduction()
                    ? "appsettings.json"
                    : $"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json";

                configBuilder
                    .AddJsonFile(settingsFileName, false, true)
                    .AddEnvironmentVariables()
                    .Build();
            })
            .ConfigureServices(services =>
            {
                services.AddHostedService<Worker>();
                services.UseRandomWeatherSource();
            })
            .UseSerilog((context, loggerConfiguration) => loggerConfiguration
                .ReadFrom.Configuration(context.Configuration))
            .Build();

        host.Run();
    }
}
