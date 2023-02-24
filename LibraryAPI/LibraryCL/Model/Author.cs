using System.ComponentModel.DataAnnotations;

namespace LibraryCL.Model
{
    public class Author : EntityBase
    {
        public Author() { }

        public Author(string firstName, string lastName) : base()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
