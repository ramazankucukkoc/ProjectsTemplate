using Application.Features.Customers.Command.CreateCustomer;
using FluentValidation;

namespace Application.Features.Customers.Validator
{
    public class CreateCustomerCommandValidator:AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.UserId).NotNull().GreaterThan(0);
        }

    }
}
