using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<AuthorBookDTO> Books { get; set; } = new List<AuthorBookDTO>();
    }
}
