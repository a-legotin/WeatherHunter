using WeatherHunter.Sources.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherHunter.Crawler.RandomSource;

public static class RandomWeatherSourceExtensions
{
    public static IServiceCollection UseRandomWeatherSource(this IServiceCollection services)
    {
        services.AddSingleton<IWeatherSource, RandomWeatherSource>();
        return services;
    }
}

