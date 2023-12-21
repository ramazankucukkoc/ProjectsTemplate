using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.UserService;
using Core.Domain.Entities;
using Core.Domain.Enums;
using MediatR;

namespace Application.Features.Auths.Command.DisableEmailAuthenticator
{
    public class DisableEmailAuthenticatorCommand : IRequest
    {
        public int UserId { get; set; }

        public class DisableEmailAuthenticatorCommandHandler : IRequestHandler<DisableEmailAuthenticatorCommand>
        {
            private readonly IUserService _userService;
            private readonly IAuthService _authService;
            private AuthBusinessRules _authBusinessRules;

            public DisableEmailAuthenticatorCommandHandler(IUserService userService, IAuthService authService, AuthBusinessRules authBusinessRules)
            {
                _userService = userService;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<Unit> Handle(DisableEmailAuthenticatorCommand request, CancellationToken cancellationToken)
            {
                User user = await _userService.GetById(request.UserId);
                await _authBusinessRules.UserShouldBeExists(user);
                await _authBusinessRules.UserShouldBeHaveAuthenticator(user);
                user.AuthenticatorType =AuthenticatorType.None;
                await _authService.DeleteOldEmailAuthenticators(user);
                await _userService.Update(user);
                return Unit.Value;
            }
        }
    }
}
