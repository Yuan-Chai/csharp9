using System;

namespace WeatherForecastRecord.Models
{
    public record WeatherForecast
    {
        public string Id { get; init; }

        public string DeviceId { get; init; }

        public DateTime Date { get; init; }

        public int Temperature { get; init; }
    }

    public class WeatherForecastModel
    {
        public string Id { get; set; }
        public string DeviceId { get; set; }
        public int Temperature { get; set; }

        public WeatherForecastModel()
        {

        }
        public WeatherForecastModel(WeatherForecast forecast)
        {
            this.Id = forecast.Id;
            this.DeviceId = forecast.DeviceId;
            this.Temperature = forecast.Temperature;
        }
    }
}
