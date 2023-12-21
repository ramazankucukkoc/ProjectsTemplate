using Application.Features.Cities.Command.DeleteCities;
using FluentValidation;

namespace Application.Features.Cities.Validator
{
    public class DeleteCitiesCommandValidator:AbstractValidator<DeleteCitiesCommand>
    {
        public DeleteCitiesCommandValidator()
        {
            RuleFor(c => c.Id).NotNull().GreaterThan(0);
        }
    }
}
