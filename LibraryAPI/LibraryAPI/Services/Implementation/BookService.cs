using AutoMapper;
using LibraryAPI.DTO;
using LibraryCL.Model;
using LibraryCL.Repository;

namespace LibraryAPI.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Book?> GetBookById(int id)
        {
            return await _unitOfWork.BookRepository.GetById(id);
        }

        public async Task<BookDTO> CreateBook(BookCreationDTO bookDto)
        {
            Book book = _mapper.Map<Book>(bookDto);
            var createdBook = await _unitOfWork.BookRepository.Create(book);
            await _unitOfWork.Save();
            return _mapper.Map<BookDTO>(createdBook);
        }

        public async Task UpdateBook(Book book, BookCreationDTO bookDto)
        {
            _mapper.Map(bookDto, book);

            _unitOfWork.BookRepository.Update(book);
            await _unitOfWork.Save();
        }

        public async Task<BookDTO?> GetBookWithAuthorById(int id)
        {
            Book? book = await _unitOfWork.BookRepository.GetById(id, book => book.Author);

            if (book == null) return null;

            return _mapper.Map<BookDTO?>(book);
        }

        public async Task DeleteBook(Book book)
        {
            _unitOfWork.BookRepository.Delete(book);
            await _unitOfWork.Save();
        }

        public List<BookDTO> GetAllBooks()
        {
            List<Book> books = _unitOfWork.BookRepository.GetAll().ToList();
            return _mapper.Map<List<BookDTO>>(books);
        }
    }
}
