using LibraryCL.Model;
using LibraryCL.Repository;
using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.Services.Implementation
{
    public class UploadImageDatabaseService : IUploadImageService
    {
        private readonly UserManager<User> _userManager;

        public UploadImageDatabaseService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task UploadImage(User user, string base64Image)
        {
            user.Avatar= base64Image;
            await _userManager.UpdateAsync(user);
        }

        public async Task RemoveImage(User user)
        {
            user.Avatar = null;
            await _userManager.UpdateAsync(user);
        }
    }
}
