using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Forecast.Domain.Models;

namespace Weather_Forecast.Domain.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<CurrentWeatherDTO> GetCurrentWeatherAsync(string city);
    }
}
