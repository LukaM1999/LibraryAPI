using System.ComponentModel.DataAnnotations;

namespace LibraryCL.Model
{
    public class Book : EntityBase
    {
        public Book() { }

        public Book(string name)
        {
            Name = name;
        }

        [MaxLength(250)]
        public string Name { get; init; }

        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }

    }
}
