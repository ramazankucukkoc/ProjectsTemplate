using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using AutoMapper;
using Core.Domain.Entities;
using MediatR;

namespace Application.Features.Auths.Command.RevokeToken
{
    public class RevokeTokenCommand : IRequest<RevokedTokenDto>
    {
        public string Token { get; set; }
        public string IpAddress { get; set; }

        public class RevokeTokenCommandHandler : IRequestHandler<RevokeTokenCommand, RevokedTokenDto>
        {
            private readonly IAuthService _authService;
            private readonly IMapper _mapper;
            private readonly AuthBusinessRules _authBusinessRules;

            public RevokeTokenCommandHandler(IAuthService authService,
                IMapper mapper, AuthBusinessRules authBusinessRules)
            {
                _authService = authService;
                _mapper = mapper;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<RevokedTokenDto> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
            {
                RefreshToken? refreshToken = await _authService.GetRefreshTokenByToken(request.Token);
                await _authBusinessRules.RefreshTokenShouldBeExists(refreshToken);
                await _authBusinessRules.RefreshTokenShouldBeExists(refreshToken);

                await _authService.RevokeRefreshToken(refreshToken, request.IpAddress, "Replaced without replacement");
                RevokedTokenDto revokedTokenDto = _mapper.Map<RevokedTokenDto>(refreshToken);
                return revokedTokenDto;
            }
        }
    }
}
