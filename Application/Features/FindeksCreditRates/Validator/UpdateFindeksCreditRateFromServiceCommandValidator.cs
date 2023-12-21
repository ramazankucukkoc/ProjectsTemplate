using Application.Features.FindeksCreditRates.Command.UpdateFindeksCreditRateFromService;
using FluentValidation;

namespace Application.Features.FindeksCreditRates.Validator
{
    public class UpdateFindeksCreditRateFromServiceCommandValidator:AbstractValidator<UpdateFindeksCreditRateFromServiceCommand>
    {
        public UpdateFindeksCreditRateFromServiceCommandValidator()
        {
            RuleFor(f => f.Id).GreaterThan(0);
            RuleFor(f => f.IdentityNumber).MinimumLength(2).NotEmpty();
        }
    }
}
