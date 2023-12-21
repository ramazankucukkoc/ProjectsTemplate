using Application.Features.Auths.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Domain.Entities;
using Core.Domain.Enums;
using Core.Security.GoogleAuth;
using Core.Security.Hashing;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task RefreshTokenShouldBeActive(RefreshToken refreshToken)
        {
            if (refreshToken.Revoked != null && DateTime.UtcNow >= refreshToken.Expires)
                throw new BusinessException("Invalid Refresh Token");
            return Task.CompletedTask;
        }
        public Task RefreshTokenShouldBeExists(RefreshToken? refreshToken)
        {
            if (refreshToken == null) throw new BusinessException("Refresh token doesn't exists.");
            return Task.CompletedTask;
        }
        public Task UserShouldBeExists(User? user)
        {
            if (user == null) throw new BusinessException(AuthBusinessExceptionMessages.UserDontExists);
            return Task.CompletedTask;
        }
        public async Task UserEmailShouldBeActive(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email.ToLower() == email.ToLower());
            if (user != null) throw new BusinessException(AuthBusinessExceptionMessages.UserMailAlreadyExists);
        }
        public async Task UserPasswordShouldBeMatch(int id, string password)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == id);
            if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                throw new BusinessException(AuthBusinessExceptionMessages.PasswordDontMatch);
        }
        public async Task UsersGoogleMailShouldBeVerified(GoogleUserDetails googleUserDetails)
        {
            if (googleUserDetails.EmailVerified == false) throw new BusinessException("Google mail has to be verified.");
        }
        public Task UserShouldBeHaveAuthenticator(User user)
        {
            if (user.AuthenticatorType == AuthenticatorType.None)
                throw new BusinessException(AuthBusinessExceptionMessages.UserHaveNotAlreadyAuthenticator);
            return Task.CompletedTask;

        }
        public Task OtpAuthenticatorThatVerifiedShouldNotBeExists(OtpAuthenticator? otpAuthenticator)
        {
            if (otpAuthenticator is not null && otpAuthenticator.IsVerified) throw new BusinessException("Already verified otp authenticator is exists.");

            return Task.CompletedTask;
        }
        public Task UserShouldNotBeHaveAuthenticator(User user)
        {
            if (user.AuthenticatorType != AuthenticatorType.None)
                throw new BusinessException(AuthBusinessExceptionMessages.UserHaveAlreadyAuthenticator);
            return Task.CompletedTask;

        }
        public Task EmailAuthenticatorShouldBeExists(EmailAuthenticator? emailAuthenticator)
        {
            if (emailAuthenticator is null) throw new BusinessException("Email authenticator don't exists.");
            return Task.CompletedTask;
        }

        public Task EmailAuthenticatorActivationKeyShouldBeExists(EmailAuthenticator? emailAuthenticator)
        {
            if (emailAuthenticator.ActivationKey is null) throw new BusinessException("Email Activation Key doesn't exists.");
            return Task.CompletedTask;
        }
        public Task OtpAuthenticatorShouldBeExists(OtpAuthenticator? otpAuthenticator)
        {
            if (otpAuthenticator is null) throw new BusinessException("Otp Authenticator don't exists.");
            return Task.CompletedTask;
        }
    }
}
