using AutoMapper;
using DotNetPOC.DTO;
using DotNetPOC.Models;

namespace DotNetPOC.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserResource>();
        }
    }
} 