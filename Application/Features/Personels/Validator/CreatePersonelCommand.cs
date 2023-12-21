using Application.Features.Personels.Command.CreatePersonel;
using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.Personels.Validator
{
    public class CreatePersonelCommandValidator : AbstractValidator<CreatePersonelCommand>
    {
        public CreatePersonelCommandValidator()
        {
            RuleFor(p => p.FirstName).FirstLetterMustBeUpperCase().MinimumLength(2).NotEmpty();
            RuleFor(p => p.LastName).FirstLetterMustBeUpperCase().MinimumLength(2).NotEmpty();
            RuleFor(p => p.Departmanid).GreaterThan(0);
            RuleFor(p => p.Gorsel).EsImagen();
        }

    }

}
