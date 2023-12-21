using Application.Features.IndividualCustomers.Queries.GetByIdIndividualCustomer;
using FluentValidation;

namespace Application.Features.IndividualCustomers.Validator
{
    public class GetByIdIndividualCustomerQueryValidator : AbstractValidator<GetByIdIndividualCustomerQuery>
    {
        public GetByIdIndividualCustomerQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
