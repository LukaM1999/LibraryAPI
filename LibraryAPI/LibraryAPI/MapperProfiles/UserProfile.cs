using AutoMapper;
using LibraryAPI.DTO;
using LibraryCL.Model;

namespace LibraryAPI.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegistrationDTO, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.SecurityStamp, opt => Guid.NewGuid().ToString());
        }
    }
}
