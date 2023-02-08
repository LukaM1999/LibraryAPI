using LibraryCL.Model;
using LibraryCL.Repository;

namespace LibraryAPI.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IGenericDbRepository<User> _userRepository;

        public UserService(IGenericDbRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _userRepository.GetById(id);
        }
    }
}
