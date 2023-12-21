using Application.Features.Products.Command;
using FluentValidation;

namespace Application.Features.Products.Validator
{
    public class DeleteProductCommandValidator:AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0);
        }
    }
}
