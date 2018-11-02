using AirJobs.Domain.Entities.Jobs;
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
