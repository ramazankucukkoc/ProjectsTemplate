using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.UserService;
using Core.Domain.Entities;
using Core.Security.JWT;
using Core.Security.MicrosoftAuth;
using MediatR;

namespace Application.Features.Auths.Command.LoginWithMicrosoft
{
    public class LoginWithMicrosoftCommand : IRequest<LoggedDto>
    {
        public string MicrosoftAccessToken { get; set; }
        public string IpAddress { get; set; }

        public class LoginWithMicrosoftCommandHandler : IRequestHandler<LoginWithMicrosoftCommand, LoggedDto>
        {
            private readonly IUserService _userService;
            private readonly IAuthService _authService;
            private readonly IMicrosoftAuthAdapter _microsoftAuthAdapter;
            private readonly AuthBusinessRules _authBusinessRules;

            public LoginWithMicrosoftCommandHandler(IUserService userService, IAuthService authService,
                IMicrosoftAuthAdapter microsoftAuthAdapter, AuthBusinessRules authBusinessRules)
            {
                _userService = userService;
                _authService = authService;
                _microsoftAuthAdapter = microsoftAuthAdapter;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<LoggedDto> Handle(LoginWithMicrosoftCommand request, CancellationToken cancellationToken)
            {
                MicrosoftUserDetail microsoftUserDetail = await _microsoftAuthAdapter.GetMicrosoftUserDetail(request.MicrosoftAccessToken);
                User? user = await _userService.GetByEmail(microsoftUserDetail.UserPrincipalName);
                await _authBusinessRules.UserShouldBeExists(user);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
                RefreshToken createdRefereshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefereshToken);
                await _authService.DeleteOldRefreshTokens(user.Id);

                return new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };


            }
        }
    }
}
