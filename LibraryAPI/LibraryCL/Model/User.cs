using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LibraryCL.Model
{
    public class User : IdentityUser
    {
        public User() {
            CreatedDate= DateTime.UtcNow;
            ModifiedDate = CreatedDate;
        }

        [MaxLength(100)]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        public string? Avatar { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }

    }
}
