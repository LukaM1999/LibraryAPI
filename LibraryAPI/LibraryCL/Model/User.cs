using System.ComponentModel.DataAnnotations;

namespace LibraryCL.Model
{
    public class User : EntityBase
    {
        public User() {
            Role = "User";
            CreatedDate= DateTime.UtcNow;
            ModifiedDate = CreatedDate;
        }

        [MaxLength(100)]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(10)]
        public string Role { get; set; }

        public string? Avatar { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }

    }
}
