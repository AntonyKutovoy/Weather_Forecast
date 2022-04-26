using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet("/save")]
        public async Task<WeatherViewModel> SaveAndShowCurrentWeatherAsync(string city)
        {
            return _mapper.Map<WeatherViewModel>(await _weatherForecastService.SaveAndShowCurrentWeatherAsync(city));
        }

        [HttpGet("/week")]
        public List<WeatherViewModel> GetWeeklyForecast()
        {
            return _mapper.Map<List<WeatherViewModel>>(_weatherForecastService.GetWeeklyForecast());
        }

        [HttpGet("/month")]
        public List<WeatherViewModel> GetMonthlyForecast()
        {
            return _mapper.Map<List<WeatherViewModel>>(_weatherForecastService.GetMonthlyForecast());
        }

        [HttpGet("/day")]
        public List<WeatherViewModel> GetDailyForecast()
        {
            return _mapper.Map<List<WeatherViewModel>>(_weatherForecastService.GetDailyForecast());
        }
    }
}
