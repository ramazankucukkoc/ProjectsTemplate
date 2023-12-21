using Application.Features.Customers.Command.UpdateCustomer;
using FluentValidation;

namespace Application.Features.Customers.Validator
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(c => c.Id).NotNull().GreaterThan(0);
            RuleFor(c => c.UserId).NotNull().GreaterThan(0);

        }

    }
}
