using Application.Features.Addresss.Command.CreateAddress;
using Application.Features.Addresss.Constants;
using FluentValidation;

namespace Application.Features.Addresss.Validator
{
    public class CreateAddreessCommandValidator : AbstractValidator<CreateAddressCommand>
    {

        public CreateAddreessCommandValidator()
        {
            RuleFor(a => a.CityId).GreaterThan(0);
            RuleFor(a => a.UserId).GreaterThan(0);
            RuleFor(a => a.AddressDetail).Length(100).NotEmpty().WithMessage(AddressValidationMessages.AddressDetailNotEmpty);

        }
    }
}
