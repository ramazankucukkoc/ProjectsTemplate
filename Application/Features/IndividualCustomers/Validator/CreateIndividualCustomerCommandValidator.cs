using Application.Features.IndividualCustomers.Command.CreateIndividualCustomer;
using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.IndividualCustomers.Validator
{
    public class CreateIndividualCustomerCommandValidator:AbstractValidator<CreateIndividualCustomerCommand>
    {
        public CreateIndividualCustomerCommandValidator()
        {
            RuleFor(i => i.CustomerId).GreaterThan(0);
            RuleFor(i => i.FirstName).MinimumLength(2).FirstLetterMustBeUpperCase().MaximumLength(50).NotEmpty();
            RuleFor(i => i.LastName).MinimumLength(2).FirstLetterMustBeUpperCase().MaximumLength(50).NotEmpty();
            RuleFor(i => i.NationalIdentity).NotEmpty().MinimumLength(11).MaximumLength(11);
        }
    }
}
