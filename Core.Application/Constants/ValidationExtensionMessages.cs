namespace Core.Application.Constants
{
    public static class ValidationExtensionMessages
    {
        public const string PasswordEmpty = "Parola Boş Olamaz!";
        public const string PasswordMinumumLength = "Minimum 8 Karakter Uzunluğunda Olmalıdır!";
        public const string PasswordMaximumLength = "Minimum 16 Karakter Uzunluğunda Olmalıdır!";
        public const string PasswordUppercaseLetter = "En Az 1 Büyük Harf İçermeledir!";
        public const string PasswordLowercaseLetter = "En Az 1 Küçük Harf İçermeledir!";
        public const string PasswordDigit = "En Az 1 Rakam İçermeledir!";
        public const string PasswordSpecialCharacter = "En Az 1 Simge İçermelidir!";

        public const string PhoneEmpty = "Telefon Numarası Boş Olamaz!";
        public const string PhoneLength = "Minimum 10 Karakter Uzunluğunda Olmalıdır!";
        public const string PhoneSpecialCharacter = "Lütfen rakam giriniz veya 5 ile başlamalısınız!";

        public const int MinumumPhoneLenght = 10;
    }
}
