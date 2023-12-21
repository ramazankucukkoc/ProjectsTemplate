using Application.Features.IndividualCustomers.Command.UpdateIndividualCustomer;
using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.IndividualCustomers.Validator
{
    public class UpdateIndividualCustomerCommandValidator : AbstractValidator<UpdateIndividualCustomerCommand>
    {
        public UpdateIndividualCustomerCommandValidator()
        {
            RuleFor(i => i.CustomerId).GreaterThan(0);
            RuleFor(i => i.Id).GreaterThan(0);
            RuleFor(i => i.FirstName).MinimumLength(2).FirstLetterMustBeUpperCase().MaximumLength(50).NotEmpty();
            RuleFor(i => i.LastName).MinimumLength(2).FirstLetterMustBeUpperCase().MaximumLength(50).NotEmpty();
            RuleFor(i => i.NationalIdentity).NotEmpty().MinimumLength(11).MaximumLength(11);
        }
    }
}
