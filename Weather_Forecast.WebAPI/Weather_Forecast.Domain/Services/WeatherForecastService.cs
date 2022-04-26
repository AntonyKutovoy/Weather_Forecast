using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Weather_Forecast.DataAccess;
using Weather_Forecast.DataAccess.Models;
using Weather_Forecast.Domain.Interfaces;
using Weather_Forecast.Domain.Models;

namespace Weather_Forecast.Domain.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        readonly string _apiKey;
        readonly string _baseUrl;
        readonly IWeatherRepository _weatherRepository;

        public HttpClient Client { get; set; }
        public WeatherForecastService(IConfiguration configuration, HttpClient client, IWeatherRepository weatherRepository)
        {
            _apiKey = configuration["ServiceApiKeys:OpenWeatherMap"];
            _baseUrl = configuration["ApiBaseUrls:Weather"];
            client.BaseAddress = new Uri(_baseUrl);
            Client = client;
            _weatherRepository = weatherRepository;
        }

        public async Task<WeatherDTO> SaveAndShowCurrentWeatherAsync(string city)
        {
            var urlParameters = $"weather?appid={_apiKey}&q={city}&units=metric";
            var response = await Client.GetAsync(urlParameters);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(responseString);
            _weatherRepository.Save(new Weather
            {
                Id = Guid.NewGuid(),
                City = (string)json.GetValue("name"),
                Description = (string)json["weather"][0]["description"],
                RequestDate = DateTime.Now,
                Humidity = (int)json.GetValue("main")["humidity"],
                Tempreture = (int)json.GetValue("main")["temp"],
                Pressure = (int)json.GetValue("main")["pressure"],
                Wind = (double)json.GetValue("wind")["speed"]
            });
            var currentWeather = new WeatherDTO()
            {
                City = (string)json.GetValue("name"),
                Description = (string)json["weather"][0]["description"],
                Humidity = (int)json.GetValue("main")["humidity"],
                Tempreture = (int)json.GetValue("main")["temp"],
                Pressure = (int)json.GetValue("main")["pressure"],
                Wind = (double)json.GetValue("wind")["speed"]
            };
            return currentWeather;
        }

        public List<WeatherDTO> GetWeeklyForecast()
        {
            return _weatherRepository.GetWeeklyForecast()
                   .Select(w => new WeatherDTO
                   {
                       City = w.City,
                       Description = w.Description,
                       Humidity = w.Humidity,
                       RequestDate = w.RequestDate,
                       Tempreture = w.Tempreture,
                       Pressure = w.Pressure,
                       Wind = w.Wind
                   })
                   .ToList();
        }

        public List<WeatherDTO> GetMonthlyForecast()
        {
            return _weatherRepository.GetMonthlyForecast()
                   .Select(w => new WeatherDTO
                   {
                       City = w.City,
                       Description = w.Description,
                       Humidity = w.Humidity,
                       RequestDate = w.RequestDate,
                       Tempreture = w.Tempreture,
                       Pressure = w.Pressure,
                       Wind = w.Wind
                   })
                   .ToList();
        }

        public List<WeatherDTO> GetDailyForecast()
        {
            return _weatherRepository.GetDailyForecast()
                   .Select(w => new WeatherDTO
                   {
                       City = w.City,
                       Description = w.Description,
                       Humidity = w.Humidity,
                       RequestDate = w.RequestDate,
                       Tempreture = w.Tempreture,
                       Pressure = w.Pressure,
                       Wind = w.Wind
                   })
                   .ToList();
        }
    }
}
