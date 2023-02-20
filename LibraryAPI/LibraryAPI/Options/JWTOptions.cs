namespace LibraryAPI.Options
{
    public class JWTOptions
    {
        public const string JWT = "JWT";

        public string ValidAudience { get; set; } = String.Empty;
        public string ValidIssuer { get; set; } = String.Empty;
        public string Secret { get; set; } = String.Empty;
    }
}
