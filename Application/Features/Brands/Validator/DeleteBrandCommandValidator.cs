using Application.Features.Brands.Command.DeleteBrand;
using FluentValidation;

namespace Application.Features.Brands.Validator
{
    public class DeleteBrandCommandValidator : AbstractValidator<DeleteBrandCommand>
    {
        public DeleteBrandCommandValidator()
        {
            RuleFor(b => b.Id).NotNull().GreaterThan(0)
                .GetType();
        }
    }
}
