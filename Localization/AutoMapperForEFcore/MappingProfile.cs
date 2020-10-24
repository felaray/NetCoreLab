using AutoMapper;
using AutoMapperForEFcore.Models;

namespace AutoMapperForEFcore
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;

            CreateMap<AppUser, AppUserDTO>().IgnoreAllPropertiesWithAnInaccessibleSetter();
            CreateMap<AppUserDTO, AppUser>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}