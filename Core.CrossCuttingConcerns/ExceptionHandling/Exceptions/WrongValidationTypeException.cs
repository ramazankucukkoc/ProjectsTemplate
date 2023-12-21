using Core.CrossCuttingConcerns.ExceptionHandling.Constants;

namespace Core.CrossCuttingConcerns.ExceptionHandling.Exceptions
{
    public class WrongValidationTypeException : Exception
    {
        public WrongValidationTypeException() : base(ExceptionMessages.WrongValidationType)
        {

        }
        public WrongValidationTypeException(string? message) : base(message)
        {

        }
        public WrongValidationTypeException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
        public static void ThrowIfWrongType(Type argument1, Type argument2)
        {
            if (argument1.IsAssignableFrom(argument2) == false)
                throw new WrongValidationTypeException();
        }

    }
}
