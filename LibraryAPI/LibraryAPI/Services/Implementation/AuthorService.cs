using AutoMapper;
using LibraryAPI.DTO;
using LibraryAPI.Exceptions;
using LibraryCL.Model;
using LibraryCL.Repository;

namespace LibraryAPI.Services.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Author?> GetAuthorById(int id)
        {
            return await _unitOfWork.AuthorRepository.GetById(id);
        }

        public async Task<AuthorDTO> CreateAuthor(AuthorCreationDTO authorDto)
        {
            Author author = _mapper.Map<Author>(authorDto);
            var createdAuthor = await _unitOfWork.AuthorRepository.Create(author);
            await _unitOfWork.Save();
            return _mapper.Map<AuthorDTO>(createdAuthor);
        }

        public async Task UpdateAuthor(Author author, AuthorCreationDTO authorDto)
        {
            author.FirstName = authorDto.FirstName;
            author.LastName = authorDto.LastName;

            _unitOfWork.AuthorRepository.Update(author);
            await _unitOfWork.Save();
        }

        public async Task<AuthorDTO?> GetAuthorWithBooksById(int id)
        {
            Author? author = await _unitOfWork.AuthorRepository.GetById(id, author => author.Books);

            if (author == null) throw new AuthorNotFoundException();

            return _mapper.Map<AuthorDTO?>(author);
        }

        public async Task DeleteAuthor(Author author)
        {
            _unitOfWork.AuthorRepository.Delete(author);
            await _unitOfWork.Save();
        }
    }
}
