using Application.Features.Personels.Dtos;
using Application.Features.Personels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Personels.Command.CreatePersonel
{
    public sealed class CreatePersonelCommand : IRequest<CreatePersonelDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Gorsel { get; set; }
        public int Departmanid { get; set; }

        public class CreatePersonelCommandHandler : IRequestHandler<CreatePersonelCommand, CreatePersonelDto>
        {
            private readonly IPersonelRepository _personelRepository;
            private readonly IMapper _mapper;
            private readonly PersonelBusinessRules _personelBusinessRules;

            public CreatePersonelCommandHandler(IPersonelRepository personelRepository,
                IMapper mapper, PersonelBusinessRules personelBusinessRules)
            {
                _personelRepository = personelRepository;
                _mapper = mapper;
                _personelBusinessRules = personelBusinessRules;
            }

            public async Task<CreatePersonelDto> Handle(CreatePersonelCommand request, CancellationToken cancellationToken)
            {
                await _personelBusinessRules.PersonelNameCanNotBeDuplicatedWhenInserted(request.FirstName + " " + request.LastName);
                Personel? mappedPersonel = _mapper.Map<Personel>(request);
                Personel addedPersonel = await _personelRepository.AddAsync(mappedPersonel);
                CreatePersonelDto createPersonelDto = _mapper.Map<CreatePersonelDto>(addedPersonel);
                return createPersonelDto;
            }
        }
    }
}
