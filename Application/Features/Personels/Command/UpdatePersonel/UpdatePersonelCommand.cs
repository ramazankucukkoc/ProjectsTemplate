using Application.Features.Personels.Dtos;
using Application.Features.Personels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Personels.Command.UpdatePersonel
{
    public sealed class UpdatePersonelCommand : IRequest<UpdatePersonelDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Gorsel { get; set; }
        public int Departmanid { get; set; }

        public class UpdatePersonelCommandHandler : IRequestHandler<UpdatePersonelCommand, UpdatePersonelDto>
        {
            private readonly IPersonelRepository _personelRepository;
            private readonly IMapper _mapper;
            private readonly PersonelBusinessRules _personelBusinessRules;

            public UpdatePersonelCommandHandler(IPersonelRepository personelRepository,
                IMapper mapper, PersonelBusinessRules personelBusinessRules)
            {
                _personelRepository = personelRepository;
                _mapper = mapper;
                _personelBusinessRules = personelBusinessRules;
            }

            public async Task<UpdatePersonelDto> Handle(UpdatePersonelCommand request, CancellationToken cancellationToken)
            {
                await _personelBusinessRules.PersonelIdControl(request.Id);
                Personel? personel = await _personelRepository.GetAsync(p => p.Id == request.Id);
                await _personelBusinessRules.PersonelNameCanNotBeDuplicatedWhenInserted(personel.FirstName + " " + personel.LastName);
                _mapper.Map(request, personel);
                await _personelRepository.UpdateAsync(personel);
                UpdatePersonelDto result = _mapper.Map<UpdatePersonelDto>(personel);
                return result;
            }
        }

    }
}
