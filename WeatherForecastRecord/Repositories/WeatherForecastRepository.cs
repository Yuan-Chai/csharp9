using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

using WeatherForecastRecord.Models;

namespace WeatherForecastRecord.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly ConcurrentDictionary<string, WeatherForecast> _db;

        public WeatherForecastRepository()
        {
            _db = new ConcurrentDictionary<string, WeatherForecast>();
        }

        public Task<string> Create(WeatherForecast weatherForecast)
        {
            var id = Guid.NewGuid().ToString();

            _db.TryAdd(id, weatherForecast with { Id = id });

            return Task.FromResult(id);
        }

        public Task<WeatherForecast> Get(string id)
        {
            _db.TryGetValue(id, out var value);
            return Task.FromResult(value);
        }

        public Task Update(string id, WeatherForecast weatherForecast)
        {
            // not thread safe
            _db[id] = weatherForecast;
            return Task.CompletedTask;
        }
    }
}