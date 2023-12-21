using Application.Features.FindeksCreditRates.Command.CreateFindeksCreditRate;
using FluentValidation;

namespace Application.Features.FindeksCreditRates.Validator
{
    public class CreateFindeksCreditRateCommandValidator : AbstractValidator<CreateFindeksCreditRateCommand>
    {
        public CreateFindeksCreditRateCommandValidator()
        {
            RuleFor(f => f.CustomerId).GreaterThan(0);
            RuleFor(f => f.Score).GreaterThanOrEqualTo(Convert.ToInt16(0)).LessThanOrEqualTo(Convert.ToInt16(1900));
        }
    }
}
