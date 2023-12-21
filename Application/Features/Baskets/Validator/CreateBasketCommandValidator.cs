using Application.Features.Baskets.Command.CreateBasket;
using FluentValidation;

namespace Application.Features.Baskets.Validator
{
    public class CreateBasketCommandValidator : AbstractValidator<CreateBasketCommand>
    {
        public CreateBasketCommandValidator()
        {
            RuleFor(b => b.ProductId).GreaterThan(0).WithMessage("Product Id 0'dan büyük olmalıdır.")
                .NotNull().WithMessage("Product Id alanı boş olamaz");
            RuleFor(b => b.UserId).GreaterThan(0).WithMessage("User Id 0'dan büyük olmalıdır.")
                .NotNull().WithMessage("User Id alanı boş olamaz");
            RuleFor(b => b.BrandId).GreaterThan(0).WithMessage("Brand Id 0'dan büyük olmalıdır.")
                   .NotNull().WithMessage("Brand Id alanı boş olamaz");
            RuleFor(b => b.Count).GreaterThan(0).WithMessage("Count alanı 0 dan büyük olmalıdır.")
                            .NotNull().WithMessage("Count alanı boş olamaz");

        }

    }
}
