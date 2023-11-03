using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using FormulRaceAPI.Dtos;

namespace FormulRaceAPI.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile(){
        CreateMap<Driver, DriverDto>().ReverseMap();
        CreateMap<Team, TeamDto>().ReverseMap();
    }
}