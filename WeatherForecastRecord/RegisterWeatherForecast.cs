using System;

using Microsoft.Extensions.DependencyInjection;

using WeatherForecastRecord.Repositories;
using WeatherForecastRecord.Services;

namespace WeatherForecastRecord
{
    public static class RegisterWeatherForecast
    {
        public static void AddWeatherForecast(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            services.AddSingleton<IWeatherForecastRepository, WeatherForecastRepository>();
        }
    }
}
