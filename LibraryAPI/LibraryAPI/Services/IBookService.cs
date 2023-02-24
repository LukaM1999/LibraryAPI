using LibraryAPI.DTO;
using LibraryCL.Model;

namespace LibraryAPI.Services
{
    public interface IBookService
    {
        Task<Book?> GetBookById(int id);
        Task<BookDTO?> GetBookWithAuthorById(int id);
        Task<BookDTO> CreateBook(BookCreationDTO bookDto);
        Task UpdateBook(Book book, BookCreationDTO bookDto);
        Task DeleteBook(Book book);
        List<BookDTO> GetAllBooks();
    }
}
