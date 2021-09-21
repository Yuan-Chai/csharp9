using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using WeatherForecastRecord.Models;

namespace WeatherForecastRecord.Services
{
    public interface IWeatherForecastService
    {
        Task<string> Create(string deviceId, int temperature);
        Task<WeatherForecast> Get(string id);
        Task Update(string id, int temperature);
    }
}