using System;
using System.Collections.Generic;
using Weather_Forecast.DataAccess.Models;

namespace Weather_Forecast.DataAccess
{
    public class SampleData
    {
        public static List<Weather> GetDefaultForecasts()
        {
            var forecasts = new List<Weather>();
            for (int i = 0; i < 9; i++)
            {
                forecasts.Add(new Weather
                {
                    Id = Guid.NewGuid(),
                    City = "City №1"+ i.ToString(),
                    RequestDate = new DateTime(2022, 4, 1 + i),
                    Description = "Normal",
                    Tempreture = 17.5 + i,
                    Pressure = 760 + i,
                    Humidity = 30 + i,
                    Wind = 10 + i
                });
            }
            for (int i = 0; i < 9; i++)
            {
                forecasts.Add(new Weather
                {
                    Id = Guid.NewGuid(),
                    City = "City №2" + i.ToString(),
                    RequestDate = new DateTime(2022, 4, 17 + i),
                    Description = "Hot",
                    Tempreture = 30 + i,
                    Pressure = 735 + i,
                    Humidity = 70 + i,
                    Wind = 20 + i
                });
            }
            for (int i = 0; i < 9; i++)
            {
                forecasts.Add(new Weather
                {
                    Id = Guid.NewGuid(),
                    City = "City №3" + i.ToString(),
                    RequestDate = new DateTime(2022, 4, 26),
                    Description = "Cold",
                    Tempreture = -20 + i,
                    Pressure = 750 + i,
                    Humidity = 10 + i,
                    Wind = 40 + i
                });
            }
            return forecasts;
        }
    }
}
