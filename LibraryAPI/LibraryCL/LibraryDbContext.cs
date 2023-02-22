using LibraryCL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryCL
{
    public class LibraryDbContext : IdentityDbContext<User>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        protected LibraryDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(user => user.Email).IsUnique();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Admin", NormalizedName = "ADMIN" });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "3b5e174e-3b0e-446f-86af-483d56fd7210", Name = "User", NormalizedName = "USER" });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "4a5e174e-3b0e-446f-86af-483d56fd7210", Name = "Librarian", NormalizedName = "LIBRARIAN" });
#if DEBUG
            modelBuilder.Entity<User>(user =>
            {
                user.HasData(
                    new User()
                    {
                        Id = "2c6f174e-3b0e-446f-86af-483d56fd7210",
                        UserName = "admin@mail.com",
                        NormalizedUserName = "ADMIN@MAIL.COM",
                        Email = "admin@mail.com",
                        NormalizedEmail = "ADMIN@MAIL.COM",
                        CreatedDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow,
                        PasswordHash = "AQAAAAEAACcQAAAAEFlyaJD2fJ9czKDU2MiOOxMDs+jqPm64BEUR8dAYAYHcRAXq8fldBTkw8lNbnrRkrA=="
                    },
                    new User()
                    {
                        Id = "3b7g174e-3b0e-446f-86af-483d56fd7210",
                        UserName = "user@mail.com",
                        Email = "user@mail.com",
                        CreatedDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow
                    },
                    new User()
                    {
                        Id = "4a8h174e-3b0e-446f-86af-483d56fd7210",
                        UserName = "librarian@mail.com",
                        Email = "librarian@mail.com",
                        CreatedDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow
                    }
                );
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>
               {
                   RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                   UserId = "2c6f174e-3b0e-446f-86af-483d56fd7210"
               },
               new IdentityUserRole<string>
               {
                   RoleId = "3b5e174e-3b0e-446f-86af-483d56fd7210",
                   UserId = "3b7g174e-3b0e-446f-86af-483d56fd7210"
               },
               new IdentityUserRole<string>
               {
                   RoleId = "4a5e174e-3b0e-446f-86af-483d56fd7210",
                   UserId = "4a8h174e-3b0e-446f-86af-483d56fd7210"
               }
            );

            modelBuilder.Entity<Author>().HasQueryFilter(author => !author.Deleted);
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    FirstName = "Tom",
                    LastName = "Paice",
                    Created = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Bob",
                    LastName = "Vance",
                    Created = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                },
                new Author
                {
                    Id = 3,
                    FirstName = "Nick",
                    LastName = "Chapsas",
                    Created = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<Book>().HasQueryFilter(book => !book.Deleted);
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Name = "Marvelous Tale of Time",
                    Created = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    AuthorId = 1,
                },
                new Book
                {
                    Id = 2,
                    Name = "Marvelous Tale of Space",
                    Created = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    AuthorId = 1,
                },
                new Book
                {
                    Id = 3,
                    Name = "Refrigeration 101",
                    Created = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    AuthorId = 2,
                },
                new Book
                {
                    Id = 4,
                    Name = "Programming 101",
                    Created = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    AuthorId = 3,
                    Deleted = true,
                }
            );
#endif
        }
    }
}
