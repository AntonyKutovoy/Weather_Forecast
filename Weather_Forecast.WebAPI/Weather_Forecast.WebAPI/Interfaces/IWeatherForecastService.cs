using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather_Forecast.WebApi.Models;

namespace Weather_Forecast.WebAPI.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<CurrentWeather> GetCurrentWeatherAsync(string city);
    }
}
