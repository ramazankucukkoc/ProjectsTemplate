using Application.Features.FindeksCreditRates.Command.UpdateByUserIdFindeksCreditRateFromService;
using FluentValidation;

namespace Application.Features.FindeksCreditRates.Validator
{
    public class UpdateByUserIdFindeksCreditRateFromServiceCommandValidator:AbstractValidator<UpdateByUserIdFindeksCreditRateFromServiceCommand>
    {
        public UpdateByUserIdFindeksCreditRateFromServiceCommandValidator()
        {
            RuleFor(f => f.UserId).NotNull().GreaterThan(0);
            RuleFor(f => f.IdentityNumber).NotEmpty().MinimumLength(2);
        }
    }
}
