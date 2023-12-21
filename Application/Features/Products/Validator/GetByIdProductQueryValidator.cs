using Application.Features.Products.Queries.GetById;
using FluentValidation;

namespace Application.Features.Products.Validator
{
    public class GetByIdProductQueryValidator : AbstractValidator<GetByIdProductQuery>
    {
        public GetByIdProductQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
