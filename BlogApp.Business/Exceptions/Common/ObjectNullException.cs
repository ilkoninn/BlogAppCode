namespace BlogApp.Business.Exceptions.Common
{
    public class ObjectNullException : Exception
    {
        public ObjectNullException() : base("JSON data is null argument!")
        {
        }

        public ObjectNullException(string? message) : base(message)
        {
        }
    }
}
