using Application.Features.Categories.Command;
using FluentValidation;

namespace Application.Features.Categories.Validators
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(c => c.Id).NotNull();
            RuleFor(c => c.ParentId).NotNull();
            RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
        }
    }
}
