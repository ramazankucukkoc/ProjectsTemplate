using Application.Features.Cities.Command.UpdateCities;
using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.Cities.Validator
{
    public class UpdateCitiesValidator:AbstractValidator<UpdateCitiesCommand>
    {
        public UpdateCitiesValidator()
        {
            RuleFor(c => c.Id).NotNull().GreaterThan(0);
            RuleFor(c => c.CountryId).NotNull().GreaterThan(0);
            RuleFor(c => c.Name).NotEmpty().FirstLetterMustBeUpperCase();

        }
    }
}
