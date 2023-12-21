using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.CrossCuttingConcerns.ExceptionHandling.HttpProblemDetails;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.ExceptionHandling.Handlers
{
    public class HttpExceptionHandler : ExceptionHandler
    {
        //Aslında bu HttpResponse HttpContext sınıfının içerisinde yer alıyor.
        private HttpResponse? _response;

        public HttpResponse? Response
        {
            get => _response ?? throw new ArgumentNullException(nameof(_response));
            set => _response = value;
        }

        protected override Task HandleException(BusinessException businessException)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            string details = new BusinessProblemDetails(businessException.Message).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandleException(ValidationException validationException)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            object errors = ((ValidationException)validationException).Errors;
            string details = new ValidationProblemDetails(validationException.Message).AsJson();

            return Response.WriteAsync(details);
        }

        protected override Task HandleException(AuthorizationException authorizationException)
        {
            Response.StatusCode = StatusCodes.Status401Unauthorized;
            string details = new AuthorizationProblemDetails(authorizationException.Message).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandleException(NotFoundException notFoundException)
        {
            Response.StatusCode = StatusCodes.Status404NotFound;
            string details = new NotFoundProblemDetails(notFoundException.Message).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandleException(Exception exception)
        {
            Response.StatusCode = StatusCodes.Status500InternalServerError;
            string details = new InternalServerErrorProblemDetails(exception.Message).AsJson();
            return Response.WriteAsync(details);
        }
    }
}
