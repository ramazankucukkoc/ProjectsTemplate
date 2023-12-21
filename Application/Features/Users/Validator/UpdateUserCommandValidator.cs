using Application.Features.Users.Commands;
using Core.Application.Extensions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Validator
{
    public class UpdateUserCommandValidator:AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.Id).GreaterThan(0);
            RuleFor(u => u.Email).EmailAddress().NotEmpty();
            RuleFor(u => u.Password).Password();
            RuleFor(u => u.FirstName).FirstLetterMustBeUpperCase().NotEmpty().MinimumLength(2);
            RuleFor(u => u.LastName).FirstLetterMustBeUpperCase().NotEmpty().MinimumLength(2);
        }
    }
}
