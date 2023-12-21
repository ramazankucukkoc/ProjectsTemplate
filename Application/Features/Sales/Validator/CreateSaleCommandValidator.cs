using Application.Features.Sales.Command.CreateSale;
using FluentValidation;

namespace Application.Features.Sales.Validator
{
    public class CreateSaleCommandValidator:AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleCommandValidator()
        {
            RuleFor(s => s.CustomerId).GreaterThan(0);
            RuleFor(s => s.ProductId).GreaterThan(0);
            RuleFor(s => s.PersonelId).GreaterThan(0);
            RuleFor(s => s.TotalPrice).GreaterThan(0);
            RuleFor(s => s.Quantity).GreaterThan(0);
        }
    }
}
