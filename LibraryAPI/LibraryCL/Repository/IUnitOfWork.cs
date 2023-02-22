using LibraryCL.Model;

namespace LibraryCL.Repository
{
    public interface IUnitOfWork
    {
        Task Save();
        IGenericDbRepository<Author> AuthorRepository { get; }
    }
}
