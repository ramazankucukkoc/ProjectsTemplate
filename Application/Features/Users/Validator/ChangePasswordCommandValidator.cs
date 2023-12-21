using Application.Features.Users.Commands;
using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.Users.Validator
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(p => p.CurrentPassword).NotEmpty().WithName("Eski şifre").WithMessage("Alanı gereklidir!");
            RuleFor(p => p.NewPassword).Password();
            RuleFor(p => p.CurrentPassword).Equal(u => u.NewPassword).WithMessage("The password doesn't match.");
        }

    }
}
