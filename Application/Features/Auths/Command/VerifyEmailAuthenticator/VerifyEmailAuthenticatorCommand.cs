using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Application.Services.UserService;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Auths.Command.VerifyEmailAuthenticator
{
    public class VerifyEmailAuthenticatorCommand : IRequest
    {
        public string ActivationKey { get; set; }

        public class VerifyEmailAuthenticatorCommandHandler : IRequestHandler<VerifyEmailAuthenticatorCommand>
        {
            private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IUserService _userService;
            public VerifyEmailAuthenticatorCommandHandler(IEmailAuthenticatorRepository emailAuthenticatorRepository,
                IAuthService authService, AuthBusinessRules authBusinessRules, IUserService userService)
            {
                _userService = userService;
                _emailAuthenticatorRepository = emailAuthenticatorRepository;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<Unit> Handle(VerifyEmailAuthenticatorCommand request, CancellationToken cancellationToken)
            {
                EmailAuthenticator? emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(e => e.ActivationKey == request.ActivationKey);
                await _authBusinessRules.EmailAuthenticatorShouldBeExists(emailAuthenticator);
                await _authBusinessRules.EmailAuthenticatorActivationKeyShouldBeExists(emailAuthenticator);
                emailAuthenticator.ActivationKey = null;
                emailAuthenticator.IsVerified = true;
                await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);

                User user = await _userService.GetById(emailAuthenticator.UserId);
                user.AuthenticatorType = Core.Domain.Enums.AuthenticatorType.Email;
                await _userService.Update(user);

                return Unit.Value;
            }
        }

    }
}
