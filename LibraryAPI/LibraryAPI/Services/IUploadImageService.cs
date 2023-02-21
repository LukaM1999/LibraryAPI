using LibraryCL.Model;

namespace LibraryAPI.Services
{
    public interface IUploadImageService
    {
        Task RemoveImage(User user);
        Task UploadImage(User user, string base64Image);
    }
}
