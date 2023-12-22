using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Application.DTOs;
using Core.Application.Pipelines.Logging;
using Core.Domain.Entities;
using Core.Mailings;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Command.Register
{
    public class RegisterCommand : IRequest<RegisteredDto>, ILoggableRequest
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IpAddress { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IMailService _mailService;

            public RegisterCommandHandler(IUserRepository userRepository, IAuthService authService, AuthBusinessRules authBusinessRules, IMailService mailService)
            {
                _userRepository = userRepository;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
                _mailService = mailService;
            }

            public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authBusinessRules.UserEmailShouldBeActive(request.UserForRegisterDto.Email);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);
                User newUser = new()
                {
                    Email = request.UserForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true,
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName
                };
                User createUser = await _userRepository.AddAsync(newUser);
                AccessToken createdAccessToken = await _authService.CreateAccessToken(createUser);

                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createUser, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);
                RegisteredDto registeredDto = new()
                {
                    AccessToken = createdAccessToken,
                    RefreshToken = addedRefreshToken
                };

                //await _mailService.SendMailAsync(new Mail
                //{
                //    ToEmail = request.UserForRegisterDto.Email,
                //    ToFullName = $"{request.UserForRegisterDto.FirstName} ${request.UserForRegisterDto.LastName}",
                //    Subject = "Register Your Email - ECommerce - Ramazan",
                //    TextBody = "Teşekkürler",
                //    HtmlBody = "Kaydetme işlemerini<strong> başarılı şekilde tamamlandı.</strong>"
                //});
                return registeredDto;
            }
        }
    }
}
