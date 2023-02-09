﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCL.Model
{
    public class Author : EntityBase
    {
        public Author(string firstName, string lastName, DateTime created)
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

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}