﻿using AirJobs.Domain.Entities.Addresses;
using AirJobs.Models.Dtos.State;
using AutoMapper;

namespace AirJobs.AutoMapper
{
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<State, StateListDto>();
        }
    }
}
