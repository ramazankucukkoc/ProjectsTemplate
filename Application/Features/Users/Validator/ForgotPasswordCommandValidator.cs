using Application.Features.Users.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Validator
{
    public class ForgotPasswordCommandValidator:AbstractValidator<ForgotPasswordCommand>
    {
        public ForgotPasswordCommandValidator()
        {
            RuleFor(u => u.Email).EmailAddress().NotEmpty();
        }
    }
}
