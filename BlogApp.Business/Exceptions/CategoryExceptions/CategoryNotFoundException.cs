namespace BlogApp.Business.Exceptions.CategoryExceptions
{
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException():base("There is not like that JSON argument in data!")
        {
        }

        public CategoryNotFoundException(string? message) : base(message)
        {
        }
    }
}
