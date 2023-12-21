using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using Core.Mailings;
using MediatR;

namespace Application.Features.Users.Commands
{
    public class DeleteUserCommnad : IRequest<DeletedUserDto>
    {
        public int Id { get; set; }

        public class DeleteUserCommnadHandler : IRequestHandler<DeleteUserCommnad, DeletedUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IMailService _mailService;


            public DeleteUserCommnadHandler(IUserRepository userRepository,
                IMapper mapper, UserBusinessRules userBusinessRules,IMailService mailService)
            {
                _mailService = mailService;
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<DeletedUserDto> Handle(DeleteUserCommnad request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserIdShouldExistsWhenSelected(request.Id);
                User mappedUser = _mapper.Map<User>(request);
                mappedUser.Status = false;
                User deletedUser = await _userRepository.UpdateAsync(mappedUser);
                DeletedUserDto deletedUserDto = _mapper.Map<DeletedUserDto>(deletedUser);
                await _mailService.SendMailAsync(new Mail
                {
                    ToEmail = mappedUser.Email,
                    ToFullName = $"{mappedUser.FirstName} ${mappedUser.LastName}",
                    Subject = "Teşekkürler",
                    TextBody = "Her şey için teşekkürler bye bye",
                    HtmlBody = "Artık üyemiz değilsiniz <strong> bye bye</strong>"
                });

                return deletedUserDto;

            }
        }
    }
}
