using Application.Features.FindeksCreditRates.Command.UpdateFindeksCreditRate;
using FluentValidation;

namespace Application.Features.FindeksCreditRates.Validator
{
    public class UpdateFindeksCreditRateCommandValidator:AbstractValidator<UpdateFindeksCreditRateCommand>
    {
        public UpdateFindeksCreditRateCommandValidator()
        {
            RuleFor(f => f.CustomerId).GreaterThan(0);
            RuleFor(f => f.Id).GreaterThan(0);
            RuleFor(f => f.Score).GreaterThanOrEqualTo(Convert.ToInt16(0)).LessThanOrEqualTo(Convert.ToInt16(1900));
        }
    }
}
