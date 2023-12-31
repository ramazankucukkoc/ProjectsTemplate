﻿using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Application.Services.UserService;
using Core.Domain.Entities;
using Core.Mailings;
using MediatR;
using System.Web;

namespace Application.Features.Auths.Command.EnableEmailAuthenticator
{
    public class EnableEmailAuthenticatorCommand : IRequest<EnabledEmailAuthenticatorDto>
    {
        public int UserId { get; set; }
        public string VerifyEmailUrlPrefix { get; set; }

        public class EnableEmailAuthenticatorHandler : IRequestHandler<EnableEmailAuthenticatorCommand, EnabledEmailAuthenticatorDto>
        {
            private readonly IUserService _userService;
            private readonly IAuthService _authService;
            private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
            private readonly IMailService _mailService;
            private readonly AuthBusinessRules _authBusinessRules;

            public EnableEmailAuthenticatorHandler(IUserService userService,
                IAuthService authService, IEmailAuthenticatorRepository emailAuthenticatorRepository,
                IMailService mailService, AuthBusinessRules authBusinessRules)
            {
                _userService = userService;
                _authService = authService;
                _emailAuthenticatorRepository = emailAuthenticatorRepository;
                _mailService = mailService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<EnabledEmailAuthenticatorDto> Handle(EnableEmailAuthenticatorCommand request, CancellationToken cancellationToken)
            {
                User user = await _userService.GetById(request.UserId);
                await _authBusinessRules.UserShouldBeExists(user);
                await _authBusinessRules.UserShouldNotBeHaveAuthenticator(user);


                user.AuthenticatorType = Core.Domain.Enums.AuthenticatorType.Email;
                await _userService.Update(user);

                EmailAuthenticator emailAuthenticator = await _authService.CreateEmailAuthenticator(user);
                EmailAuthenticator addedEmialAuthenticator = await _emailAuthenticatorRepository.AddAsync(emailAuthenticator);

              await _mailService.SendMailAsync(new Mail
                {
                    ToEmail = user.Email,
                    ToFullName = $"{user.FirstName} ${user.LastName}",
                    Subject = "Verify Your Email - ECommerce",
                    TextBody = $"Click on the link to verify your email: {request.VerifyEmailUrlPrefix}?ActivationKey={HttpUtility.UrlEncode(addedEmialAuthenticator.ActivationKey)}"
                });
                return new EnabledEmailAuthenticatorDto { ActivationKey = addedEmialAuthenticator.ActivationKey };
            }
        }
    }
}
