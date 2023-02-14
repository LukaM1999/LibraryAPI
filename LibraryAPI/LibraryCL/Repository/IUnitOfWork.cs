using LibraryCL.Model;
using LibraryCL.Repository.Implementation;

namespace LibraryCL.Repository
{
    public interface IUnitOfWork
    {
        Task Save();
    }
}
