using AutoMapper;
using DotNetPOC.Resources;
using DotNetPOC.Models;
using System;
using DotNetPOC.Utils;

namespace DotNetPOC.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<ProgramGroupResource, ProgramGroup>()
            .ForMember(
                    d => d.CreatedAt, 
                    opt => opt.MapFrom(src => DateTime.Parse(long.Parse(src.CreatedAt).ToString())));
                    
            CreateMap<ProgramGroup, ProgramGroupResource>()
            .ForMember(
                    d => d.CreatedAt, 
                    opt => opt.MapFrom(src => TimeConverter.DateTimeToUnixTime(src.CreatedAt).ToString()));
            
        }
    }
} 