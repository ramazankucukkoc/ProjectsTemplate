using Application.Features.Products.Command;
using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.Products.Validator
{
    public class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().FirstLetterMustBeUpperCase().MinimumLength(2);
            RuleFor(c => c.ShortDescription).NotEmpty().FirstLetterMustBeUpperCase().MinimumLength(2).MaximumLength(50);
            RuleFor(c => c.Description).NotEmpty().FirstLetterMustBeUpperCase().MinimumLength(2).MaximumLength(200);
            RuleFor(c => c.SKU).NotEmpty().MinimumLength(2);
            RuleFor(c => c.BrandId).GreaterThan(0);
            RuleFor(c => c.ProductBranchId).GreaterThan(0);
            RuleFor(c => c.RegularPrice).LessThan(c=>c.SalePrice);
            RuleFor(c => c.SalePrice).GreaterThan(c => c.RegularPrice);
            RuleFor(c => c.Rating).InclusiveBetween(0, 5);
            RuleFor(c => c.CategoryId).GreaterThan(0);
            RuleFor(c => c.DiscountRate).InclusiveBetween(0, 100);

        }
    }
}
