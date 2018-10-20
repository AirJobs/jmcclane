using AirJobs.Domain.Entities.Address;
using AirJobs.Models.Dtos.City;
using AirJobs.Models.ViewModels;
using AutoMapper;

namespace AirJobs.AutoMapper
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityListDto>();
        }
    }
}
