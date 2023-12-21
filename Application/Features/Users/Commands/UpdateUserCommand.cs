using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Mailings;
using Core.Security.Hashing;
using MediatR;

namespace Application.Features.Users.Commands
{
    public class UpdateUserCommand : IRequest<UpdateUserDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IMailService _mailService;


            public UpdateUserCommandHandler(IUserRepository userRepository,
                IMapper mapper, UserBusinessRules userBusinessRules,IMailService mailService)
            {
                _mailService = mailService;
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }
            public async Task<UpdateUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserConNotBeDuplicatedWhenUpdated(request.Id, request.Email);
                User mappedUser = _mapper.Map<User>(request);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                mappedUser.PasswordHash = passwordHash;
                mappedUser.PasswordSalt = passwordSalt;
                User updatedUser = await _userRepository.UpdateAsync(mappedUser);
                UpdateUserDto updateUserDto = _mapper.Map<UpdateUserDto>(updatedUser);
                await _mailService.SendMailAsync(new Mail
                {
                    ToEmail = request.Email,
                    TextBody = "Teşekkürler Bilginiz Güncellendi.",
                    ToFullName = $"{request.FirstName} ${request.LastName}",
                    Subject = "Kullanıcı Your Update - RamoCommerce -RamoBaba",
                    HtmlBody = "Kullanıcı güncelleme işlemleri <strong>Başarılı şekilde güncellendi.</strong>"
                });
                return updateUserDto;
            }
        }

    }
}
