using Castle.Core.Internal;

namespace LibraryAPI.Security
{
    public static class Hasher
    {
        public static string HashPassword(string password)
        {
            if (password.IsNullOrEmpty()) throw new ArgumentNullException("password");
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
