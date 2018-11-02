using AirJobs.Domain.Entities.Jobs;
using AirJobs.Models.Dtos.Job;
using AutoMapper;

namespace AirJobs.AutoMapper
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<Job, JobListDto>()
                .ForMember(x => x.Stars, config => config.MapFrom(x => x.GetAverageRating()));

            CreateMap<Job, JobItemDto>()
                .ForMember(x => x.Street, opt => opt.MapFrom(x => x.Address.Street))
                .ForMember(x => x.Number, opt => opt.MapFrom(x => x.Address.Number))
                .ForMember(x => x.Neighborhood, opt => opt.MapFrom(x => x.Address.Neighborhood))
                .ForMember(x => x.CityName, opt => opt.MapFrom(x => x.Address.City.Name))
                .ForMember(x => x.State, opt => opt.MapFrom(x => x.Address.City.State.UF))
                .ForMember(x => x.CountryName, opt => opt.MapFrom(x => x.Address.City.State.Country.Name));

            CreateMap<JobCreateDto, Job>();
        }
    }
}
