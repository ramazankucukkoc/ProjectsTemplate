using Application.Features.Brands.Queries.GetByIdBrand;
using FluentValidation;

namespace Application.Features.Brands.Validator
{
    public class GetByIdBrandQueryValidator : AbstractValidator<GetByIdBrandQuery>
    {
        public GetByIdBrandQueryValidator()
        {
            RuleFor(b => b.Id).NotNull().GreaterThan(0);

        }
    }
}
