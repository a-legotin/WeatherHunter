using WeatherHunter.Abstractions;
using WeatherHunter.Sources.Abstractions;

namespace WeatherHunter.Crawler.RandomSource;

internal class RandomWeatherSource : IWeatherSource
{
    public Forecast GetCurrentTimeForecast()
    {
        return new Forecast
        {
            LocationCoordinate = new Coordinate { Latitude = 1, Longitude = 2 },
            Summary = "weather summary",
            TemperatureC = new Random(DateTime.Now.Millisecond).Next(0, 35)
        };
    }
}

