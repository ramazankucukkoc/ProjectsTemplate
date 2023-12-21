using Application.Features.Brands.Command.UpdateBrand;
using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.Brands.Validator
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {
            RuleFor(b => b.Id).NotNull().GreaterThan(0).ExclusiveBetween(0, int.MaxValue);
            RuleFor(b => b.Name).NotEmpty().FirstLetterMustBeUpperCase().MinimumLength(2);
        }

    }
}
