using AirJobs.Domain.Entities.User;
using AirJobs.Models.Dtos.Scheduling;
using AirJobs.Models.ViewModels;
using AutoMapper;

namespace AirJobs.AutoMapper
{
    public class SchedulingProfile : Profile
    {
        public SchedulingProfile()
        {
            CreateMap<SchedulingCreateDto, Scheduling>();
            CreateMap<Scheduling, SchedulingListDto>();
        }
    }
}
