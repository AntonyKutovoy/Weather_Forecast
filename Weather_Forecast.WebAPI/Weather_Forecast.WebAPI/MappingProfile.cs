using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather_Forecast.Domain.Models;
using Weather_Forecast.WebApi.Models;

namespace Weather_Forecast.WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CurrentWeatherDTO, CurrentWeatherViewModel>().ReverseMap();
            CreateMap<WeatherForecastDTO, WeatherForecastViewModel>().ReverseMap();
        }
    }
}
