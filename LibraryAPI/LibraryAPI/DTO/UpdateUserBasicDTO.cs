using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.DTO
{
    public class UpdateUserBasicDTO
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
    }
}
