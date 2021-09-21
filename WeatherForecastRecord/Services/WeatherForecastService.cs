using System;
using System.Threading.Tasks;

using WeatherForecastRecord.Models;
using WeatherForecastRecord.Repositories;

namespace WeatherForecastRecord.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _repo;

        public WeatherForecastService(IWeatherForecastRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> Create(string deviceId, int temperature)
        {
            WeatherForecast forecast = new()
            {
                DeviceId = deviceId,
                Date = DateTime.UtcNow,
                Temperature = temperature,
            };

            return await _repo.Create(forecast);
        }

        public async Task<WeatherForecast> Get(string id)
        {
            return await _repo.Get(id);
        }

        public async Task Update(string id, int temperature)
        {
            var forecast = await _repo.Get(id);

            forecast = forecast with { Temperature = temperature };

            await _repo.Update(id, forecast);
        }
    }
}