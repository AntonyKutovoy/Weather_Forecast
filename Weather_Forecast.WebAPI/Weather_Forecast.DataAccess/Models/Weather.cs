using System;
using System.ComponentModel.DataAnnotations;

namespace Weather_Forecast.DataAccess.Models
{
    public class Weather
    {
        [Key]
        public Guid Id { get; set; }
        public string City { get; set; }
        public DateTime RequestDate { get; set; }
        public string Description { get; set; }
        public double Tempreture { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double Wind { get; set; }
    }
}
