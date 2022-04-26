using System.Collections.Generic;
using System.Threading.Tasks;
using Weather_Forecast.Domain.Models;

namespace Weather_Forecast.Domain.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<WeatherDTO> SaveAndShowCurrentWeatherAsync(string city);
        List<WeatherDTO> GetWeeklyForecast();
        List<WeatherDTO> GetMonthlyForecast();
        List<WeatherDTO> GetDailyForecast();
    }
}
