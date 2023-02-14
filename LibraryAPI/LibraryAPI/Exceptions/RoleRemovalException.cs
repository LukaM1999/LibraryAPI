namespace LibraryAPI.Exceptions
{
    public class RoleRemovalException : Exception
    {
        public RoleRemovalException()
        {
        }

        public RoleRemovalException(string message)
            : base(message)
        {
        }

        public RoleRemovalException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
