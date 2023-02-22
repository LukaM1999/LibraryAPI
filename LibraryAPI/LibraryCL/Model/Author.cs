using System.ComponentModel.DataAnnotations;

namespace LibraryCL.Model
{
    public class Author : EntityBase
    {
        public Author() { }

        public Author(string firstName, string lastName, DateTime created) : base()
        {
            FirstName = firstName;
            LastName = lastName;
            Created = created;
            ModifiedDate = created;
        }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime Created { get; init; }

        [Required]
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
