using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCL.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryCL
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        protected LibraryDbContext()
        {
        }

        private DbSet<User> _users;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.HasData(
                    new { Id = 1, Email = "email@mail.com", 
                        Password = "SecurePass123!", Role = "User", 
                        CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now 
                    }
                );
            });
        }
    }
}
