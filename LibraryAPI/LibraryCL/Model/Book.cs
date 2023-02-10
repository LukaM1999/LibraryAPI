using System.ComponentModel.DataAnnotations;

namespace LibraryCL.Model
{
    public class Book : EntityBase
    {
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

        public virtual ICollection<Author> Authors { get; set; } = new List<Author>();

    }
}
