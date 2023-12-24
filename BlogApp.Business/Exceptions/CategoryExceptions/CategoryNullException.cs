namespace BlogApp.Business.Exceptions.CategoryExceptions
{
    public class CategoryNullException : Exception
    {
        public CategoryNullException():base("JSON data is null argument!")
        {
        }

        public CategoryNullException(string? message) : base(message)
        {
        }
    }
}
