using System.Collections.Generic;
using Weather_Forecast.DataAccess.Models;

namespace Weather_Forecast.DataAccess
{
    public interface IWeatherRepository
    {
        void Save(Weather weather);
        List<Weather> GetMonthlyForecast();
        List<Weather> GetWeeklyForecast();
        List<Weather> GetDailyForecast();
    }
}
