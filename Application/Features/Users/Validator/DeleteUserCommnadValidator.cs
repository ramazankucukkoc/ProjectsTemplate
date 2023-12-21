using Application.Features.Users.Commands;
using FluentValidation;

namespace Application.Features.Users.Validator
{
    public class DeleteUserCommnadValidator:AbstractValidator<DeleteUserCommnad>
    {
        public DeleteUserCommnadValidator()
        {
            RuleFor(u => u.Id).GreaterThan(0);
        }
    }
}
