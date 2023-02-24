namespace LibraryAPI.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AuthorBasicDTO Author { get; set; }
    }
}
