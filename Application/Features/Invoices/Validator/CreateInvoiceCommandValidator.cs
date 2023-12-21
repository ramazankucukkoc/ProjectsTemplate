using Application.Features.Invoices.Command.CreateInvoice;
using FluentValidation;

namespace Application.Features.Invoices.Validator
{
    public class CreateInvoiceCommandValidator:AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
        {
            RuleFor(i => i.CustomerId).GreaterThan(0);
            RuleFor(i => i.ProductId).GreaterThan(0);
            RuleFor(i => i.TotalSum).GreaterThan(0);
        }

    }
}
