using AutoMapper;
using DotNetPOC.Resources;
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