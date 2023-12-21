using Application.Features.FindeksCreditRates.Command.DeleteFindeksCreditRate;
using FluentValidation;

namespace Application.Features.FindeksCreditRates.Validator
{
    public class DeleteFindeksCreditRateCommandValidator : AbstractValidator<DeleteFindeksCreditRateCommand>
    {
        public DeleteFindeksCreditRateCommandValidator()
        {
            RuleFor(f => f.Id).NotNull().GreaterThan(0);
        }
    }
}
