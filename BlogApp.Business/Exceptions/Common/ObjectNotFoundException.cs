namespace BlogApp.Business.Exceptions.Common
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException() : base("There is not like that JSON argument in data!")
        {
        }

        public ObjectNotFoundException(string? message) : base(message)
        {
        }
    }
}
