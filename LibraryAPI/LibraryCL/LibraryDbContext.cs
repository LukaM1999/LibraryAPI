using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private DbSet<Entity> _entities;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
