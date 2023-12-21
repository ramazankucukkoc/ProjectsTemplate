using Application.Features.Personels.Dtos;
using Application.Features.Personels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Personels.Command.DeletePersonel
{
    public sealed class DeletePersonelCommand : IRequest<DeletePersonelDto>
    {
        public int Id { get; set; }

        public class DeletePersonelCommandHandler : IRequestHandler<DeletePersonelCommand, DeletePersonelDto>
        {
            private readonly IPersonelRepository _personelRepository;
            private readonly IMapper _mapper;
            private readonly PersonelBusinessRules _businessRules;

            public DeletePersonelCommandHandler(IPersonelRepository personelRepository,
                IMapper mapper, PersonelBusinessRules businessRules)
            {
                _personelRepository = personelRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<DeletePersonelDto> Handle(DeletePersonelCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.PersonelIdControl(request.Id);
                Personel? personel = await _personelRepository.GetAsync(p => p.Id == request.Id);
                personel.Active = false;
                Personel deletedPersonel = await _personelRepository.UpdateAsync(personel);
                DeletePersonelDto result = _mapper.Map<DeletePersonelDto>(deletedPersonel);
                return result;
            }
        }

    }
}
