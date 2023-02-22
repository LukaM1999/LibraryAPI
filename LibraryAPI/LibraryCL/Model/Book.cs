using System.ComponentModel.DataAnnotations;

namespace LibraryCL.Model
{
    public class Book : EntityBase
    {
        public Book() { }

        public Book(string name, DateTime created)
        {
            Name = name;
            Created = created;
            ModifiedDate = created;
        }

        [MaxLength(250)]
        public string Name { get; init; }

        [Required]
        public DateTime Created { get; init; }

        [Required]
        public DateTime ModifiedDate { get; set; }

        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }

    }
}
