using Application.Features.Cities.Command.CreateCities;
using FluentValidation;

namespace Application.Features.Cities.Validator
{
    public class CreateCitiesCommandValidator : AbstractValidator<CreateCitiesCommand>
    {
        public CreateCitiesCommandValidator()
        {
            RuleFor(c => c.CountryId).Null().NotEmpty();
            RuleFor(c => c.Name).NotEmpty();

        }
    }
}
