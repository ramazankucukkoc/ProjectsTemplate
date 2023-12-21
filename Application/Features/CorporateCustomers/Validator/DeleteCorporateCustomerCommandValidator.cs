using Application.Features.CorporateCustomers.Command.DeleteCorporateCustomer;
using FluentValidation;

namespace Application.Features.CorporateCustomers.Validator
{
    public class DeleteCorporateCustomerCommandValidator:AbstractValidator<DeleteCorporateCustomerCommand>
    {
        public DeleteCorporateCustomerCommandValidator()
        {
            RuleFor(c => c.Id).NotNull().GreaterThan(0);
        }
    }
}
