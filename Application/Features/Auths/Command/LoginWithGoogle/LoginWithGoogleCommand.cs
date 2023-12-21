using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.UserService;
using Core.Domain.Entities;
using Core.Security.GoogleAuth;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Command.LoginWithGoogle
{
    public class LoginWithGoogleCommand : IRequest<LoggedDto>
    {
        public LoginWithGoogleDto LoginWithGoogleDto { get; set; }
        public string IpAddrres { get; set; }

        public class LoginWithGoogleCommandHandler : IRequestHandler<LoginWithGoogleCommand, LoggedDto>
        {
            private readonly IGoogleAuthAdapter _googleAuthAdapter;
            private readonly IAuthService _authService;
            private readonly IUserService _userService;
            private readonly AuthBusinessRules _authBusinessRules;


            public LoginWithGoogleCommandHandler(IGoogleAuthAdapter googleAuthAdapter,
                IAuthService authService, IUserService userService, AuthBusinessRules authBusinessRules)
            {

                _googleAuthAdapter = googleAuthAdapter;
                _authService = authService;
                _userService = userService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<LoggedDto> Handle(LoginWithGoogleCommand request, CancellationToken cancellationToken)
            {

                GoogleUserDetails googleUserDetails = await _googleAuthAdapter.GetGoogleUserDetails(request.LoginWithGoogleDto.GoogleAccessToken);
                await _authBusinessRules.UsersGoogleMailShouldBeVerified(googleUserDetails);

                User? user = await _userService.GetByEmail(googleUserDetails.Email);
                await _authBusinessRules.UserShouldBeExists(user);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddrres);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);
                await _authService.DeleteOldRefreshTokens(user.Id);

                return new LoggedDto
                {
                    AccessToken = createdAccessToken,
                    RefreshToken = addedRefreshToken
                };
            }
        }
    }
}
