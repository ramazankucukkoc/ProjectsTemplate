using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Application.Services.UserService;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Auths.Command.EnableOtpAuthenticator
{
    public class EnableOtpAuthenticatorCommand : IRequest<EnabledOtpAuthenticatorDto>
    {
        public int UserId { get; set; }

        public class EnableOtpAuthenticatorCommandHandler : IRequestHandler<EnableOtpAuthenticatorCommand, EnabledOtpAuthenticatorDto>
        {
            private readonly IUserService _userService;
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IOtpAuthenticatorRepository _authenticatorRepository;

            public EnableOtpAuthenticatorCommandHandler(IUserService userService, IAuthService authService,
                AuthBusinessRules authBusinessRules, IOtpAuthenticatorRepository authenticatorRepository)
            {
                _userService = userService;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
                _authenticatorRepository = authenticatorRepository;
            }

            public async Task<EnabledOtpAuthenticatorDto> Handle(EnableOtpAuthenticatorCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userService.GetById(request.UserId);
                await _authBusinessRules.UserShouldBeExists(user);
                await _authBusinessRules.UserShouldNotBeHaveAuthenticator(user);

                OtpAuthenticator? isExistsOtpAuthenticator = await _authenticatorRepository.GetAsync(o => o.UserId == request.UserId);
                await _authBusinessRules.OtpAuthenticatorThatVerifiedShouldNotBeExists(isExistsOtpAuthenticator);
                if (isExistsOtpAuthenticator is not null)
                    await _authenticatorRepository.DeleteAsync(isExistsOtpAuthenticator);

                OtpAuthenticator newOtpAuthenticator = await _authService.CreateOtpAuthenticator(user);
                OtpAuthenticator addedOtpAuthenticator = await _authenticatorRepository.AddAsync(newOtpAuthenticator);

                EnabledOtpAuthenticatorDto enabledOtpAuthenticatorDto = new() { SecretKey = await _authService.ConvertSecretKeyToString(addedOtpAuthenticator.SecretKey) };
               
                return enabledOtpAuthenticatorDto;
           
            }
        }
    }
}
