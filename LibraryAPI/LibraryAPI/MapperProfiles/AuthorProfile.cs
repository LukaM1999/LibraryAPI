using AutoMapper;
using LibraryAPI.DTO;
using LibraryCL.Model;

namespace LibraryAPI.MapperProfiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorCreationDTO, Author>();
            CreateMap<AuthorDTO, Author>().ReverseMap();
            CreateMap<AuthorBasicDTO, Author>().ReverseMap();
        }
    }
}
