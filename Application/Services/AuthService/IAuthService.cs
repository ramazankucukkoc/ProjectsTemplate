using Core.Domain.Entities;
using Core.Security.JWT;

namespace Application.Services.AuthService
{
    public interface IAuthService
    {
        Task<AccessToken> CreateAccessToken(User user);
        Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
        Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
        Task DeleteOldRefreshTokens(int userId);
        Task<EmailAuthenticator> CreateEmailAuthenticator(User user);
        Task<OtpAuthenticator> CreateOtpAuthenticator(User user);
        Task DeleteOldOtpAuthenticators(User user);
        Task DeleteOldEmailAuthenticators(User user);
        Task<string> ConvertSecretKeyToString(byte[] secretKey);
        Task VerifyAuthenticatorCode(User user, string AuthenticatorCode);
        Task<RefreshToken> GetRefreshTokenByToken(string token);
        Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason);
        Task RevokeRefreshToken(RefreshToken refreshToken, string ipAddress, string? reason = null, string? replacedByToken = null);
        Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress);

    }
}
