using LibraryCL.Model;
using LibraryCL.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCL.Repository
{
    public interface IUnitOfWork
    {
        GenericDbRepository<User> UserRepository { get; }
        Task Save();
    }
}
