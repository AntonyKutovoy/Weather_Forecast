using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Forecast.DataAccess.Models
{
    public class Weather
    {
        public long CityId { get; set; }
        public string City { get; set; }
        public long ExactDate { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public double Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double Wind { get; set; }
        public string Icon { get; set; }
    }
}
