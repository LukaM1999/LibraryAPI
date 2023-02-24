using LibraryAPI.DTO;
using LibraryCL.Model;
using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.Services
{
    public interface IUserService
    {
        Task<User?> GetUserById(string id);
        Task<User?> GetUserByEmail(string email);
        Task<UserDTO?> GetUserDTOByEmail(string email);
        Task<IdentityResult> RegisterUser(UserRegistrationDTO userRegistrationDto);
        Task UpgradeUserToLibrarian(string userId);
        Task DowngradeLibrarianToUser(string userId);
        Task<LoginResponseDTO> Login(LoginDTO loginDTO);
        Task UpdateBasicInformation(User user, UpdateUserBasicDTO updateUserDTO);
        Task UpdateEmail(User user, string email);
        Task UpdateAvatar(User user, string base64Image);
        Task RemoveAvatar(User user);
    }
}
