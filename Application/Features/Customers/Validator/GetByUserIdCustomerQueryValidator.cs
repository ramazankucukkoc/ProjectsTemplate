using Application.Features.Customers.Queries.GetByUserIdCustomer;
using FluentValidation;

namespace Application.Features.Customers.Validator
{
    public class GetByUserIdCustomerQueryValidator:AbstractValidator<GetByUserIdCustomerQuery>
    {
        public GetByUserIdCustomerQueryValidator()
        {
            RuleFor(c => c.UserId).NotNull().GreaterThan(0);
        }

    }
}
