using Application.Features.Auths.Constants;
using Core.Application.Extensions;
using FluentValidation;

namespace Application.Features.Auths.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.UserForRegisterDto.Email).NotEmpty().WithMessage(AuthValidatorMessages.EmailDoesNot)
                .EmailAddress().WithMessage(AuthValidatorMessages.EmailFormatDoesNot);
            RuleFor(x => x.UserForRegisterDto.Password).Password();
            RuleFor(x => x.UserForRegisterDto.FirstName).NotEmpty().WithMessage(AuthValidatorMessages.FirstNameNotEmpty)
                .MinimumLength(2).WithMessage("Adınız en az 3 karekterden oluşmalıdır.");

            RuleFor(x => x.UserForRegisterDto.LastName).NotEmpty().WithMessage(AuthValidatorMessages.LastNameNotEmpty)
               .MinimumLength(2).WithMessage("Soyadınız en az 3 karekterden oluşmalıdır.");

        }
    }
}
