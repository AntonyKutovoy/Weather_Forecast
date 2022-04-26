using System;

namespace Weather_Forecast.Domain.Models
{
    public class WeatherDTO
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
