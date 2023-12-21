using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Security.Hashing;
using MediatR;

namespace Application.Features.Users.Commands
{
    public class UpdateUserFromAuthCommand : IRequest<UpdatedUserFromAuthDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }

        public class UpdateUserFromAuthCommandHandler : IRequestHandler<UpdateUserFromAuthCommand, UpdatedUserFromAuthDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IAuthService _authService;


            public UpdateUserFromAuthCommandHandler(IUserRepository userRepository, IMapper mapper,
                UserBusinessRules userBusinessRules, IAuthService authService)
            {
                _authService = authService;
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<UpdatedUserFromAuthDto> Handle(UpdateUserFromAuthCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(u => u.Id == request.Id);
                await _userBusinessRules.UserShouldBeExists(user);
                await _userBusinessRules.UserPasswordShouldBeMatch(user, request.Password);

                user.FirstName = request.FirstName;
                user.LastName = request.LastName;

                //Burası bir dünüşünülmeli çünkü Validation işlemleri null check yapıyor.
                if (request.NewPassword is not null && !string.IsNullOrWhiteSpace(request.Password))
                {
                    byte[] passwordHash, passwordSalt;
                    HashingHelper.CreatePasswordHash(request.NewPassword, out passwordHash, out passwordSalt);
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                }

                User updateUser = await _userRepository.UpdateAsync(user);
                UpdatedUserFromAuthDto updateUserFromAuthDto = _mapper.Map<UpdatedUserFromAuthDto>(updateUser);
                updateUserFromAuthDto.AccessToken = await _authService.CreateAccessToken(user);
                return updateUserFromAuthDto;
            }
        }

    }
}
