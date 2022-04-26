using System;
using System.Collections.Generic;
using System.Linq;
using Weather_Forecast.DataAccess.Models;

namespace Weather_Forecast.DataAccess
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public WeatherRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public void Save(Weather weather)
        {
            _dataBaseContext.Weathers.Add(weather);
            _dataBaseContext.SaveChanges();
        }

        public List<Weather> GetWeeklyForecast()
        {
            var weeklyWeatherForecasts = new List<Weather>();
            foreach (var weather in GetAll())
            {
                if (weather.RequestDate.AddDays(7) >= DateTime.Now)
                {
                    weeklyWeatherForecasts.Add(weather);
                }
            }
            return weeklyWeatherForecasts;
        }

        public List<Weather> GetMonthlyForecast()
        {
            var monthlyWeatherForecasts = new List<Weather>();
            foreach (var weather in GetAll())
            {
                if (weather.RequestDate.AddDays(30) >= DateTime.Now)
                {
                    monthlyWeatherForecasts.Add(weather);
                }
            }
            return monthlyWeatherForecasts;
        }

        public List<Weather> GetDailyForecast()
        {
            var dailyWeatherForecasts = new List<Weather>();
            foreach (var weather in GetAll())
            {
                if (weather.RequestDate.Day == DateTime.Now.Day)
                {
                    dailyWeatherForecasts.Add(weather);
                }
            }
            return dailyWeatherForecasts;
        }

        private List<Weather> GetAll()
        {
            return _dataBaseContext.Weathers.ToList();
        }
    }
}
