using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using Core.Security.EmailAuthenticator;
using Core.Security.JWT;
using Core.Security.OtpAuthenticator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.Services.AuthService
{
    public class AuthManager : IAuthService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly TokenOptions _tokenOptions;
        private readonly IEmailAuthenticatorHelper _emailAuthenticatorHelper;
        private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
        private readonly IOtpAuthenticatorRepository _otpAuthenticatorRepository;
        private readonly IOtpAuthenticatorHelper _otpAuthenticatorHelper;
        public AuthManager(IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper,
            IRefreshTokenRepository refreshTokenRepository, IEmailAuthenticatorHelper emailAuthenticatorHelper,
            IConfiguration configuration, IEmailAuthenticatorRepository emailAuthenticatorRepository,
            IOtpAuthenticatorRepository otpAuthenticatorRepository, IOtpAuthenticatorHelper otpAuthenticatorHelper)

        {
            _otpAuthenticatorHelper = otpAuthenticatorHelper;
            _otpAuthenticatorRepository = otpAuthenticatorRepository;
            _emailAuthenticatorRepository = emailAuthenticatorRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _emailAuthenticatorHelper = emailAuthenticatorHelper;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            RefreshToken token = await _refreshTokenRepository.AddAsync(refreshToken);
            return token;
        }

        public async Task<string> ConvertSecretKeyToString(byte[] secretKey)
        {
            return await _otpAuthenticatorHelper.ConvertSecretKeyToString(secretKey);
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IPaginate<UserOperationClaim> userOperationClaims =
                await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id,
                include: u => u.Include(x => x.OperationClaim));

            IList<OperationClaim> operationClaims =
                userOperationClaims.Items.Select(x => new OperationClaim
                {
                    Id = x.OperationClaim.Id,
                    Name = x.OperationClaim.Name,
                }).ToArray();
            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }

        public async Task<EmailAuthenticator> CreateEmailAuthenticator(User user)
        {
            EmailAuthenticator emailAuthenticator = new()
            {
                UserId = user.Id,
                ActivationKey = await _emailAuthenticatorHelper.CreateEmailActivationKey(),
                IsVerified = false
            };
            return emailAuthenticator;
        }

        public async Task<OtpAuthenticator> CreateOtpAuthenticator(User user)
        {
            OtpAuthenticator otpAuthenticator = new()
            {
                UserId = user.Id,
                SecretKey = await _otpAuthenticatorHelper.GenerateSecretKey(),
                IsVerified = false
            };

            return otpAuthenticator;
        }

        public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
        {
            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            return Task.FromResult(refreshToken);
        }

        public async Task DeleteOldEmailAuthenticators(User user)
        {
            IList<EmailAuthenticator> emailAuthenticators = (await _emailAuthenticatorRepository.GetListAsync(e => e.UserId == user.Id)).Items;
            foreach (EmailAuthenticator emailAuthenticator in emailAuthenticators)
                await _emailAuthenticatorRepository.DeleteAsync(emailAuthenticator);

        }

        public async Task DeleteOldOtpAuthenticators(User user)
        {
            IList<OtpAuthenticator> otpAuthenticators = (await _otpAuthenticatorRepository.GetListAsync(o => o.UserId == user.Id)).Items;
            foreach (OtpAuthenticator otpAuthenticator in otpAuthenticators)
                await _otpAuthenticatorRepository.DeleteAsync(otpAuthenticator);

        }
        public async Task DeleteOldRefreshTokens(int userId)
        {
            IList<RefreshToken> refreshTokens = (await _refreshTokenRepository.GetListAsync(r =>
            r.UserId == userId &&
            r.Revoked == null && r.Expires >= DateTime.UtcNow &&
            r.Created.AddDays(_tokenOptions.RefreshTokenTTL) <=
            DateTime.UtcNow)).Items;
            foreach (RefreshToken refreshToken in refreshTokens) await _refreshTokenRepository.DeleteAsync(refreshToken);
        }

        public async Task<RefreshToken> GetRefreshTokenByToken(string token)
        {
            RefreshToken? refreshToken = await _refreshTokenRepository.GetAsync(r => r.Token == token);
            return refreshToken;

        }

        public async Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason)
        {
            RefreshToken? childToken = await _refreshTokenRepository.GetAsync(r => r.Token == refreshToken.ReplacedByToken);

            if (childToken != null && childToken.Revoked != null && childToken.Expires <= DateTime.UtcNow)
                await RevokeRefreshToken(refreshToken, ipAddress, reason);

            else await RevokeDescendantRefreshTokens(refreshToken, ipAddress, reason);

        }

        public async Task RevokeRefreshToken(RefreshToken refreshToken, string ipAddress, string? reason = null, string? replacedByToken = null)
        {
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReasonRevoked = reason;
            refreshToken.ReplacedByToken = replacedByToken;
            await _refreshTokenRepository.UpdateAsync(refreshToken);

        }

        public async Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress)
        {
            RefreshToken newRefreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            await RevokeRefreshToken(refreshToken, ipAddress, "Replace by new token", newRefreshToken.Token);
            return newRefreshToken;
        }
        public async Task VerifyAuthenticatorCode(User user, string AuthenticatorCode)
        {
            if (user.AuthenticatorType is Core.Domain.Enums.AuthenticatorType.Email)
                await verifyAuthenticatorCodeWithEmail(user, AuthenticatorCode);

            else if (user.AuthenticatorType is Core.Domain.Enums.AuthenticatorType.Otp)
                await verifyAuthenticatorCodeWithOtp(user, AuthenticatorCode);

        }
        private async Task verifyAuthenticatorCodeWithEmail(User user, string authenticatorCode)
        {
            EmailAuthenticator? emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(e => e.UserId == user.Id);
            if (emailAuthenticator.ActivationKey != authenticatorCode)
                throw new BusinessException("Authenticator code is invalid.");

            emailAuthenticator.ActivationKey = null;
            await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);

        }
        private async Task verifyAuthenticatorCodeWithOtp(User user, string authenticatorCode)
        {
            OtpAuthenticator? otpAuthenticator = await _otpAuthenticatorRepository.GetAsync(o => o.UserId == user.Id);

            bool result = await _otpAuthenticatorHelper.VerifyCode(otpAuthenticator.SecretKey, authenticatorCode);

            if (!result)
                throw new BusinessException("Authenticator code is invalid.");

        }
    }
}
