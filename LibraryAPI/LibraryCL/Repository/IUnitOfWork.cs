using LibraryCL.Model;
using LibraryCL.Repository.Implementation;

namespace LibraryCL.Repository
{
    public interface IUnitOfWork
    {
        GenericDbRepository<User> UserRepository { get; }
        Task Save();
    }
}
