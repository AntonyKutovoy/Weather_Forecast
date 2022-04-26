using AutoMapper;
using Weather_Forecast.Domain.Models;
using Weather_Forecast.WebApi.Models;

namespace Weather_Forecast.WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WeatherDTO, WeatherViewModel>().ReverseMap();
        }
    }
}
