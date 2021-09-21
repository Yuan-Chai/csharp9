using System.Collections.Generic;
using System.Threading.Tasks;

using WeatherForecastRecord.Models;

namespace WeatherForecastRecord.Repositories
{
    public interface IWeatherForecastRepository
    {
        Task<string> Create(WeatherForecast weatherForecast);
        Task<WeatherForecast> Get(string id);
        Task Update(string id, WeatherForecast weatherForecast);
    }
}