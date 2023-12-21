using Application.Features.Users.Commands;
using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.Users.Validator
{
    public class UpdateUserFromAuthCommandValidator:AbstractValidator<UpdateUserFromAuthCommand>
    {
        public UpdateUserFromAuthCommandValidator()
        {
            RuleFor(u => u.FirstName).FirstLetterMustBeUpperCase().NotEmpty().MinimumLength(2);
            RuleFor(u => u.LastName).FirstLetterMustBeUpperCase().NotEmpty().MinimumLength(2);
            RuleFor(u => u.Password).Password();
            RuleFor(u => u.NewPassword).Password().NotEqual(u => u.Password);
        }
    }
}
