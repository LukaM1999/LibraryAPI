namespace LibraryAPI.Exceptions
{
    public class UserUpdateException : Exception
    {
        public UserUpdateException()
        {
        }

        public UserUpdateException(string message)
            : base(message)
        {
        }

        public UserUpdateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
