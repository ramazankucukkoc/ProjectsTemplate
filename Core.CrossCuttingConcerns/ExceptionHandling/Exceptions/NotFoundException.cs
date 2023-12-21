namespace Core.CrossCuttingConcerns.ExceptionHandling.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
