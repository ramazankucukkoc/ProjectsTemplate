using Application.Features.CorporateCustomers.Queries.GetByCustomerIdCorporateCustomer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomers.Validator
{
    public class GetByCustomerIdCorporateCustomerQueryValidator:AbstractValidator<GetByCustomerIdCorporateCustomerQuery>
    {
        public GetByCustomerIdCorporateCustomerQueryValidator()
        {
            RuleFor(c => c.CustomerId).NotNull().GreaterThan(0);
        }
    }
}
