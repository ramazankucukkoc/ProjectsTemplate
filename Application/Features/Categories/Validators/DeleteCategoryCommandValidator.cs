using Application.Features.Categories.Command;
using FluentValidation;

namespace Application.Features.Categories.Validators
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(c => c.Id).NotNull().WithMessage("Id Alanı Boş Olamaz!");
        }

    }
}
