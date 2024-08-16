namespace WeatherHunter.Abstractions;

public class Forecast
{
    public required Coordinate LocationCoordinate { get; set; }
    public int TemperatureC { get; set; }
    public required string Summary { get; set; }

    public override string ToString()
    {
        return $"{Summary}, Temperature {TemperatureC} C";
    }
}
