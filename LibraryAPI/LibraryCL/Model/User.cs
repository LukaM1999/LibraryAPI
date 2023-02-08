using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCL.Model
{
    public class User : EntityBase
    {
        public User() { }

        [NotNull]
        public string Email { get; set; } = string.Empty;
    }
}
