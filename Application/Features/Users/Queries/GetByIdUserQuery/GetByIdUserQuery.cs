using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries.GetByIdUserQuery
{
    public sealed class GetByIdUserQuery : IRequest<GetByIdUserDto>
    {
        public int UserId { get; set; }

        public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, GetByIdUserDto>
        {
            private readonly UserBusinessRules _userBusinessRules;
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetByIdUserQueryHandler(UserBusinessRules userBusinessRules, IUserRepository userRepository, IMapper mapper)
            {
                _userBusinessRules = userBusinessRules;
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdUserDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserIdShouldExistsWhenSelected(request.UserId);
                User? user = await _userRepository.GetAsync(u => u.Id == request.UserId, include: u => u.Include(u => u.UserOperationClaims).ThenInclude(u => u.OperationClaim));
                GetByIdUserDto getByIdUserDto = _mapper.Map<GetByIdUserDto>(user);
                return getByIdUserDto;
            }
        }

    }
}
