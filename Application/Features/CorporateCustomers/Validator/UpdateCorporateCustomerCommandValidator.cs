using Application.Features.Categories.Command;
using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.CorporateCustomers.Validator
{
    public class UpdateCorporateCustomerCommandValidator:AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCorporateCustomerCommandValidator()
        {
            RuleFor(c => c.Id).NotNull().GreaterThan(0);
            RuleFor(c=>c.ParentId).NotNull().GreaterThan(0);
            RuleFor(c => c.Name).NotEmpty().FirstLetterMustBeUpperCase().MinimumLength(2);
        }

    }
}
