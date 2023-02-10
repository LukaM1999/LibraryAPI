using AutoMapper;
using LibraryAPI.DTO;
using LibraryCL.Model;

namespace LibraryAPI.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegistrationDTO, User>();
        }
    }
}
