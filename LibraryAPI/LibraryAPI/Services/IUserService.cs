using LibraryAPI.DTO;
using LibraryCL.Model;

namespace LibraryAPI.Services
{
    public interface IUserService
    {
        Task<User?> GetUserById(int id);
        Task RegisterUser(UserRegistrationDTO userRegistrationDto);
    }
}
