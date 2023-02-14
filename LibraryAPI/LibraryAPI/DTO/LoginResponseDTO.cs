namespace LibraryAPI.DTO
{
    public class LoginResponseDTO
    {
        public string JWT { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
