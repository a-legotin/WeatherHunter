using WeatherHunter.Sources.Abstractions;

namespace WeatherHunter.Crawler;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IWeatherSource _weatherSource;

    public Worker(ILogger<Worker> logger, IWeatherSource weatherSource)
    {
        _logger = logger;
        _weatherSource = weatherSource;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Current time: {Time}, expected weather: {@Weather}", DateTimeOffset.Now, _weatherSource.GetCurrentTimeForecast());
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }
}

