using Application.Features.Products.Queries.GetByCategoryId;
using FluentValidation;

namespace Application.Features.Products.Validator
{
    public class GetByCategoryIdQueryValidator : AbstractValidator<GetByCategoryIdQuery>
    {
        public GetByCategoryIdQueryValidator()
        {
            RuleFor(x => x.CategoryId).GreaterThan(0);
        }
    }
}
