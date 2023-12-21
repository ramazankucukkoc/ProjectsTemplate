using Application.Features.Auths.Constants;
using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.Auths.Command.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.UserForLoginDto.Email).NotEmpty().WithMessage(AuthValidatorMessages.EmailDoesNot)
                .EmailAddress().WithMessage(AuthValidatorMessages.EmailFormatDoesNot);
            RuleFor(x => x.UserForLoginDto.Password).Password();
        }

    }
}
