using LibraryAPI.DTO;
using LibraryCL.Model;
using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.Services
{
    public interface IUserService
    {
        Task<User?> GetUserById(string id);
        Task<IdentityResult> RegisterUser(UserRegistrationDTO userRegistrationDto);
        Task UpgradeUserToLibrarian(string userId);
        Task DowngradeLibrarianToUser(string userId);
    }
}
