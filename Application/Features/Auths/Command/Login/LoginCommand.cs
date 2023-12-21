using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.UserService;
using Core.Application.DTOs;
using Core.Domain.Entities;
using Core.Mailings;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Command.Login
{
    public class LoginCommand : IRequest<LoggedDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedDto>
        {
            private readonly IUserService _userService;
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IMailService _mailService;

            public LoginCommandHandler(IUserService userService
                , IAuthService authService, AuthBusinessRules authBusinessRules, IMailService mailService)
            {
                _userService = userService;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
                _mailService = mailService;
            }

            public async Task<LoggedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userService.GetByEmail(request.UserForLoginDto.Email);
                await _authBusinessRules.UserShouldBeExists(user);
                await _authBusinessRules.UserPasswordShouldBeMatch(user.Id, request.UserForLoginDto.Password);
                AccessToken createdAccessToken = await _authService.CreateAccessToken(user);

                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                return new LoggedDto() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
            }
        }
    }
}
