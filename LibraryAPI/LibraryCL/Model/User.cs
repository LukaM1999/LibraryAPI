using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCL.Model
{
    public class User : EntityBase
    {
        public User(string email, string password, string role, DateTime createdDate)
        {
            Email = email;
            Password = password;
            Role = role;
            CreatedDate = createdDate;
            ModifiedDate = createdDate;
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
