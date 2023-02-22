using AutoMapper;
using LibraryAPI.DTO;
using LibraryCL.Model;

namespace LibraryAPI.MapperProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile() { 
            CreateMap<AuthorBookDTO, Book>().ReverseMap();
        }
    }
}
