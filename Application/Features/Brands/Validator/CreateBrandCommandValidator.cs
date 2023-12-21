using Application.Features.Brands.Command.CreateBrand;
using FluentValidation;

namespace Application.Features.Brands.Validator
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(b => b.Name).NotEmpty().WithName("Brand Name").MinimumLength(2);
        }
    }
}
