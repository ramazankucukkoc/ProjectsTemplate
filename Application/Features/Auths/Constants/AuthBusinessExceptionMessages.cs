namespace Application.Features.Auths.Constants
{
    public static class AuthBusinessExceptionMessages
    {
        public const string UserDontExists = "User don't exists.";
        public const string UserMailAlreadyExists = "User mail already exists.";
        public const string PasswordDontMatch = "Password don't match.";//Password eşleşmiyor.
        public const string UserHaveAlreadyAuthenticator = "User have already a authenticator.";
        public const string UserHaveNotAlreadyAuthenticator = "User have not a authenticator.";

    }
}
