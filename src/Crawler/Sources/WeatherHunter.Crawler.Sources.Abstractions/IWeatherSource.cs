using WeatherHunter.Abstractions;

namespace WeatherHunter.Sources.Abstractions;

public interface IWeatherSource
{
    public Forecast GetCurrentTimeForecast();
}
