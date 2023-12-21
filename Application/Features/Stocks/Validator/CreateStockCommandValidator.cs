using Application.Features.Stocks.Command.CreateStock;
using FluentValidation;

namespace Application.Features.Stocks.Validator
{
    public class CreateStockCommandValidator:AbstractValidator<CreateStockCommand>
    {
        public CreateStockCommandValidator()
        {
            RuleFor(s => s.ProductId).GreaterThan(0);
            RuleFor(s => s.Quantity).NotNull().GreaterThan(0);
        }
    }
}
