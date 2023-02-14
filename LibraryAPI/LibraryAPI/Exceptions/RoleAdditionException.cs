namespace LibraryAPI.Exceptions
{
    public class RoleAdditionException : Exception
    {
        public RoleAdditionException()
        {
        }

        public RoleAdditionException(string message)
            : base(message)
        {
        }

        public RoleAdditionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
