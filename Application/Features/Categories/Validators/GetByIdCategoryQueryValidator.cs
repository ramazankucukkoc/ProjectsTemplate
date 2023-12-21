using Application.Features.Categories.Queries.GetById;
using FluentValidation;

namespace Application.Features.Categories.Validators
{
    public class GetByIdCategoryQueryValidator : AbstractValidator<GetByIdCategoryQuery>
    {
        public GetByIdCategoryQueryValidator()
        {
            RuleFor(x => x.Id).NotNull();

        }
    }
}
