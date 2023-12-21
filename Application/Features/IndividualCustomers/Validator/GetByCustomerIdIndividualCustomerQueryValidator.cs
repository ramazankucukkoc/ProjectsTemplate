using Application.Features.IndividualCustomers.Queries.GetByCustomerIdIndividualCustomer;
using FluentValidation;

namespace Application.Features.IndividualCustomers.Validator
{
    public class GetByCustomerIdIndividualCustomerQueryValidator:AbstractValidator<GetByCustomerIdIndividualCustomerQuery>
    {
        public GetByCustomerIdIndividualCustomerQueryValidator()
        {
            RuleFor(x => x.CustomerId).GreaterThan(0);
        }
    }
}
