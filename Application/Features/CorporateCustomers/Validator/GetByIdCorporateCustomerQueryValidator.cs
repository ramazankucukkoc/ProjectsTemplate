using Application.Features.CorporateCustomers.Queries.GetByIdCorporateCustomer;
using FluentValidation;

namespace Application.Features.CorporateCustomers.Validator
{
    public class GetByIdCorporateCustomerQueryValidator:AbstractValidator<GetByIdCorporateCustomerQuery>
    {
        public GetByIdCorporateCustomerQueryValidator()
        {
            RuleFor(c => c.Id).NotNull().GreaterThan(0);
        }
    }
}
