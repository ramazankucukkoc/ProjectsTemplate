using Application.Features.IndividualCustomers.Command.DeleteIndividualCustomer;
using FluentValidation;

namespace Application.Features.IndividualCustomers.Validator
{
    public class DeleteIndividualCustomerCommandValidator:AbstractValidator<DeleteIndividualCustomerCommand>
    {
        public DeleteIndividualCustomerCommandValidator()
        {
            RuleFor(i => i.Id).GreaterThan(0);
        }
    }
}
