using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.UserService;
using Core.Domain.Entities;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Command.RefleshToken
{
    //Reflesh:Yenile
    public class RefreshTokenCommand : IRequest<RefreshedTokensDto>
    {
        public string? RefleshToken { get; set; }
        public string? IpAddress { get; set; }

        public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshedTokensDto>
        {
            private readonly IAuthService _authService;
            private readonly IUserService _userService;
            private readonly AuthBusinessRules _businessRules;

            public RefreshTokenCommandHandler(IAuthService authService,
                IUserService userService, AuthBusinessRules businessRules)
            {
                _authService = authService;
                _userService = userService;
                _businessRules = businessRules;
            }

            public async Task<RefreshedTokensDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
            {
                RefreshToken? refreshToken = await _authService.GetRefreshTokenByToken(request.RefleshToken);
                await _businessRules.RefreshTokenShouldBeExists(refreshToken);
                if (refreshToken.Revoked != null)
                    await _authService.RevokeDescendantRefreshTokens(refreshToken, request.IpAddress, $"Attempted reuse of revoked ancestor token: {refreshToken.Token}");

                await _businessRules.RefreshTokenShouldBeActive(refreshToken);
                User user = await _userService.GetById(refreshToken.UserId);
                RefreshToken newRefreshToken = await _authService.RotateRefreshToken(user, refreshToken, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(newRefreshToken);

                await _authService.DeleteOldRefreshTokens(refreshToken.UserId);
                AccessToken createdAccessToken = await _authService.CreateAccessToken(user);

                return new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };

            }
        }
    }
}
