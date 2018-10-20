using AirJobs.Domain.Entities.Job;
using AirJobs.Models.Dtos.Job;
using AutoMapper;

namespace AirJobs.AutoMapper
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Job, JobListDto>();
        }
    }
}
