using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
