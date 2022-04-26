using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Weather_Forecast.Domain.Interfaces;
using Weather_Forecast.WebApi.Models;

namespace Weather_Forecast.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly IMapper _mapper;

        public WeatherForecastController(IWeatherForecastService weatherForecastService, IMapper mapper)
        {
            _weatherForecastService = weatherForecastService;
            _mapper = mapper;
        }

        [HttpGet("current/{city}")]
        public async Task<CurrentWeatherViewModel> GetCurrentWeatherAsync(string city)
        {
            return _mapper.Map<CurrentWeatherViewModel>(await _weatherForecastService.GetCurrentWeatherAsync(city));
        }

        //[HttpGet("forecast/{city}")]
        //public async Task<IList<WeatherForecastViewModel>> GetForecastsAsync(string city)
        //{
        //    return await _weatherForecastService.GetForecastsAsync(city);
        //}
    }
}
