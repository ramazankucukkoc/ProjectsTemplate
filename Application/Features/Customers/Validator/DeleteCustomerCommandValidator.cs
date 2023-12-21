using Application.Features.Customers.Command.DeleteCustomer;
using FluentValidation;

namespace Application.Features.Customers.Validator
{
    public class DeleteCustomerCommandValidator:AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(c => c.Id).NotNull().GreaterThan(0);
        }

    }
}
