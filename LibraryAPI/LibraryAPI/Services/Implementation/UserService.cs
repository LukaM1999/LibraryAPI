using AutoMapper;
using LibraryAPI.DTO;
using LibraryAPI.Security;
using LibraryCL.Model;
using LibraryCL.Repository;
using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;

        }

        public async Task<User?> GetUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<IdentityResult> RegisterUser(UserRegistrationDTO userRegistrationDto)
        {
            User user = _mapper.Map<User>(userRegistrationDto);

            var creationResult = await _userManager.CreateAsync(user, userRegistrationDto.Password);
            if(!creationResult.Succeeded)
            {
                return creationResult;
            }

            return await _userManager.AddToRoleAsync(user, Roles.User);
        }

        public async Task UpgradeUserToLibrarian(string userId)
        {
            var user = await GetUserById(userId);
            if(user == null)
            {
                throw new ApplicationException(nameof(user));
            }

            var roleRemovalResult = await _userManager.RemoveFromRoleAsync(user, Roles.User);
            if (!roleRemovalResult.Succeeded)
            {
                throw new ApplicationException(nameof(user));
            }

            var roleAdditionResult = await _userManager.AddToRoleAsync(user, Roles.Librarian);
            if (!roleAdditionResult.Succeeded)
            {
                throw new ApplicationException(nameof(user));
            }
        }

        public async Task DowngradeLibrarianToUser(string userId)
        {
            var user = await GetUserById(userId);
            if (user == null)
            {
                throw new ApplicationException(nameof(user));
            }

            var roleRemovalResult = await _userManager.RemoveFromRoleAsync(user, Roles.Librarian);
            if (!roleRemovalResult.Succeeded)
            {
                throw new ApplicationException(nameof(user));
            }

            var roleAdditionResult = await _userManager.AddToRoleAsync(user, Roles.User);
            if (!roleAdditionResult.Succeeded)
            {
                throw new ApplicationException(nameof(user));
            }
        }
    }
}
