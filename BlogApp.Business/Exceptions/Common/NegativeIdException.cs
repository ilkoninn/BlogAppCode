namespace BlogApp.Business.Exceptions.Common
{
    public class NegativeIdException : Exception
    {
        public NegativeIdException():base("Id can't be negative or zero or not be null!")
        {
        }

        public NegativeIdException(string? message) : base(message)
        {
        }
    }
}
