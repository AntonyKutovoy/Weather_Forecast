using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Weather_Forecast.Domain.Interfaces;
using Weather_Forecast.Domain.Models;

namespace Weather_Forecast.Domain.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        readonly string _apiKey;
        readonly string _baseUrl;

        public HttpClient Client { get; set; }
        public WeatherForecastService(IConfiguration configuration, HttpClient client)
        {
            _apiKey = configuration["ServiceApiKeys:OpenWeatherMap"];
            _baseUrl = configuration["ApiBaseUrls:Weather"];

            client.BaseAddress = new Uri(_baseUrl);
            Client = client;
        }

        public async Task<CurrentWeatherDTO> GetCurrentWeatherAsync(string city)
        {
            var urlParameters = $"weather?appid={_apiKey}&q={city}&units=metric";

            var response = await Client.GetAsync(urlParameters);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var json = JObject.Parse(responseString);

            var currentWeather = new CurrentWeatherDTO()
            {
                CityId = (long)json.GetValue("id"),
                City = (string)json.GetValue("name"),
                Description = (string)json["weather"][0]["description"],
                Icon = (string)json["weather"][0]["icon"],
                Humidity = (int)json.GetValue("main")["humidity"],
                Temp = (int)json.GetValue("main")["temp"],
                Pressure = (int)json.GetValue("main")["pressure"],
                Wind = (double)json.GetValue("wind")["speed"]
            };

            return currentWeather;
        }
    }
}
