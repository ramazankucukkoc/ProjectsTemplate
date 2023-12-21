using Application.Features.CorporateCustomers.Command.CreateCorporateCustomer;
using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.CorporateCustomers.Validator
{
    public class CreateCorporateCustomerCommandValidator:AbstractValidator<CreateCorporateCustomerCommand>
    {
        public CreateCorporateCustomerCommandValidator()
        {
            RuleFor(c => c.CustomerId).NotNull().GreaterThan(0);
            RuleFor(c => c.CompanyName).NotEmpty().FirstLetterMustBeUpperCase().MinimumLength(2);
            RuleFor(c => c.TaxNo).NotEmpty().MinimumLength(2);
        }
    }
}
