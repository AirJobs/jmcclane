using AirJobs.Domain.Entities.User;
using AirJobs.Domain.ValueObjects;
using AirJobs.IdentityServer.Models;
using AirJobs.Models.Dtos.User;
using AirJobs.Models.ViewModels;
using AutoMapper;

namespace AirJobs.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>()
                .ForMember(user => user.Name, from => from.MapFrom(vm => new Name(vm.FirstName, vm.LastName)));

            CreateMap<User, UserItemDto>()
                .ForMember(vm => vm.FirstName, from => from.MapFrom(user => user.Name.FirstName))
                .ForMember(vm => vm.LastName, from => from.MapFrom(user => user.Name.LastName));
        }
    }
}
