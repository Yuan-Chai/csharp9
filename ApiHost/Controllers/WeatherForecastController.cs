using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using WeatherForecastRecord.Models;
using WeatherForecastRecord.Services;

namespace csharp9.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(WeatherForecastModel weatherForecast)
        {
            var id = await _weatherForecastService.Create(weatherForecast.DeviceId, weatherForecast.Temperature);
            return new OkObjectResult(new { Id = id });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<WeatherForecastModel> Get(string id)
        {
            var result = await _weatherForecastService.Get(id);
            return new WeatherForecastModel(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(WeatherForecastModel weatherForecast)
        {
            if (weatherForecast is not null && !string.IsNullOrEmpty(weatherForecast.Id)
                && weatherForecast.Temperature is >= 0 and <= 30)
            {
                await _weatherForecastService.Update(weatherForecast.Id, weatherForecast.Temperature);
                return new OkResult();
            }
            else
            {
                return new BadRequestResult();
            }
        }
    }
}
