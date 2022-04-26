using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Weather_Forecast.WebApi.Models;
using Weather_Forecast.WebAPI.Interfaces;

namespace Weather_Forecast.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet("current/{city}")]
        public async Task<CurrentWeather> GetCurrentWeatherAsync(string city)
        {
            return await _weatherForecastService.GetCurrentWeatherAsync(city);
        }
    }
}
