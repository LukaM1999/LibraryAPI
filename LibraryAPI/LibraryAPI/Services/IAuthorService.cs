using LibraryAPI.DTO;
using LibraryCL.Model;

namespace LibraryAPI.Services
{
    public interface IAuthorService
    {
        Task<Author?> GetAuthorById(int id);
        Task<AuthorDTO?> GetAuthorWithBooksById(int id);
        Task<AuthorDTO> CreateAuthor(AuthorCreationDTO author);
        Task UpdateAuthor(Author author, AuthorCreationDTO authorDto);
        Task DeleteAuthor(Author author);
        List<AuthorDTO> GetAllAuthors();
    }
}
