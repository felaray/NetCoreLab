using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapperForEFcore.Models;
using System.Security.Cryptography;

namespace AutoMapperForEFcore
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {


            CreateMap<AppUser, AppUserDTO>(MemberList.Source);
            CreateMap<AppUserDTO, AppUser>(MemberList.Source);

            CreateMap<LogDTO, Log>(MemberList.Source);
            CreateMap<Log, LogDTO>(MemberList.Source);

            //CreateMap<AppUser, AppUserDTO>().EqualityComparison((odto, o) => odto.Id == o.Id);
            //CreateMap<AppUserDTO, AppUser>().EqualityComparison((odto, o) => odto.Id == o.Id);

            //CreateMap<LogDTO, Log>().EqualityComparison((odto, o) => odto.Id == o.Id);
            //CreateMap<Log, LogDTO>().EqualityComparison((odto, o) => odto.Id == o.Id);

        }
    }
}