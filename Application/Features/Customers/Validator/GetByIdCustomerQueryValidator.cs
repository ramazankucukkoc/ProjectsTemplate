using Application.Features.Customers.Queries.GetByIdCustomer;
using FluentValidation;

namespace Application.Features.Customers.Validator
{
    public class GetByIdCustomerQueryValidator:AbstractValidator<GetByIdCustomerQuery>
    {
        public GetByIdCustomerQueryValidator()
        {
            RuleFor(c => c.Id).NotNull().GreaterThan(0);
        }
    }
}
