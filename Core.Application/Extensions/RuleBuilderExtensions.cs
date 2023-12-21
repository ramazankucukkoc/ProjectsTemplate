using Core.Application.Constants;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Core.Application.Extensions
{
    public static class RuleBuilderExtensions
    {

        public static IRuleBuilder<T,string>NotEmptyMessages<T>(this IRuleBuilder<T,string> ruleBuilder)
        {
            var options = ruleBuilder.NotEmpty().WithMessage($"{ruleBuilder.GetType().Name} boş geçilemez");
            return options;
        }
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder, 
            int minimumLength = 8,int maximumLength=16)
        {
            var options = ruleBuilder
                .NotEmpty().WithMessage(ValidationExtensionMessages.PasswordEmpty)
                .MaximumLength(maximumLength).WithMessage(ValidationExtensionMessages.PasswordMaximumLength)
                .MinimumLength(minimumLength).WithMessage(ValidationExtensionMessages.PasswordMinumumLength)
                 .Matches("[A-Z]").WithMessage(ValidationExtensionMessages.PasswordUppercaseLetter)
                 .Matches("[a-z]").WithMessage(ValidationExtensionMessages.PasswordLowercaseLetter)
                 .Matches("[0-9]").WithMessage(ValidationExtensionMessages.PasswordDigit)
                  .Matches("[^a-zA-Z0-9]").WithMessage(ValidationExtensionMessages.PasswordSpecialCharacter);
            return options;
        }
        public static IRuleBuilderOptions<T, string> FirstLetterMustBeUpperCase<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(strToCheck => Char.IsUpper(strToCheck[0])).WithMessage("The first letter is not uppercase");
        }
        public static IRuleBuilder<T, string> IsPhoneValid<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty().WithMessage(ValidationExtensionMessages.PhoneEmpty)
                .MinimumLength(ValidationExtensionMessages.MinumumPhoneLenght).WithMessage(ValidationExtensionMessages.PhoneLength)
                .Must(IsPhoneValid).WithMessage(ValidationExtensionMessages.PhoneSpecialCharacter);
            return options;
        }
        public static IRuleBuilderOptions<T, string> EsImagen<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(EsImagen).WithMessage("Wrong format file. It must be an image.");
        }
        public static bool IsPhoneValid(string mobilePhone)
        {
            if (string.IsNullOrWhiteSpace(mobilePhone))
                return false;

            mobilePhone = Regex.Replace(mobilePhone, "[^0-9]", "");
            return mobilePhone.StartsWith("5") && mobilePhone.Length == 10;
        }
        private static bool EsImagen(string imagen)
        {
            return imagen != null ? imagen.EndsWith(".jpg") || imagen.EndsWith(".png") : true;
        }

    }
}
