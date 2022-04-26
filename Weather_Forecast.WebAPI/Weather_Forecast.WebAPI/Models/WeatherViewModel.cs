using System;

namespace Weather_Forecast.WebApi.Models
{
    public class WeatherViewModel
    {
        public string City { get; set; }
        public DateTime RequestDate { get; set; }
        public string Description { get; set; }
        public double Tempreture { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double Wind { get; set; }
    }
}
