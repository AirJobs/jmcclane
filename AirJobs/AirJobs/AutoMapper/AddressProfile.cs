using AirJobs.Domain.Entities.Addresses;
using AirJobs.Models.Dtos.Address;
using AirJobs.Models.ViewModels;
using AutoMapper;
using GeoCoordinatePortable;

namespace AirJobs.AutoMapper
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressCreateDto, Address>()
                .ForMember(address => address.GeoLocation, from => from.MapFrom(vm => new GeoCoordinate(vm.Latitude, vm.Longitude)));

            CreateMap<Address, AddressListDto>()
                .ForMember(vm => vm.Latitude, from => from.MapFrom(address => address.GeoLocation.Latitude))
                .ForMember(vm => vm.Longitude, from => from.MapFrom(address => address.GeoLocation.Longitude));

            CreateMap<Address, AddressItemDto>()
                .ForMember(vm => vm.Latitude, from => from.MapFrom(address => address.GeoLocation.Latitude))
                .ForMember(vm => vm.Longitude, from => from.MapFrom(address => address.GeoLocation.Longitude))
                .ForMember(vm => vm.CityName, opt => opt.MapFrom(x => x.City.Name))
                .ForMember(vm => vm.StateName, opt => opt.MapFrom(x => x.City.State.Name))
                .ForMember(vm => vm.CountryName, opt => opt.MapFrom(x => x.City.State.Country.Name));
        }
    }
}
