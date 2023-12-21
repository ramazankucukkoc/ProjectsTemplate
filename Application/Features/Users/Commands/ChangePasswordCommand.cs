using Application.Features.Auths.Rules;
using Application.Services.Repositories;
using Core.Domain.Entities;
using Core.Mailings;
using Core.Security.Hashing;
using MediatR;

namespace Application.Features.Users.Commands
{
    public class ChangePasswordCommand : IRequest<string>
    {
        public int UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, string>
        {
            private readonly IUserRepository _userRepository;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IMailService _mailService;


            public ChangePasswordCommandHandler(IUserRepository userRepository, AuthBusinessRules authBusinessRules
                ,IMailService mailService)
            {
                _mailService = mailService;
                _userRepository = userRepository;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<string> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(x => x.Id == request.UserId);
                await _authBusinessRules.UserShouldBeExists(user);

                byte[] passwordHash, passwordSalt;

                await _authBusinessRules.UserPasswordShouldBeMatch(request.UserId, request.NewPassword.Trim());
                HashingHelper.CreatePasswordHash(request.NewPassword, out passwordHash, out passwordSalt);


                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                await _userRepository.UpdateAsync(user);
                await _mailService.SendMailAsync(new Mail
                {
                    ToEmail = user.Email,
                    ToFullName = $"{user.FirstName} ${user.LastName}",
                    Subject = "PasswordChanded Your Email - RamoCommerce - RamoBaba",
                    TextBody = "Teşekkürler",
                    HtmlBody = "Şifre değiştirme işlemi başarılı şekilde tamamlandı"
                });
                return "Şifre değiştirme işlemi başarılı şekilde tamamlandı";

            }
        }

    }
}
