using Application.Features.Baskets.Command.DeleteBasket;
using FluentValidation;

namespace Application.Features.Baskets.Validator
{
    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(b => b.Id).NotNull().WithMessage("Id Alanı boş geçilmez!")
                .GreaterThan(0).WithMessage("Id alanı 0'dan büyük olmalıdır!");


        }
    }
}
