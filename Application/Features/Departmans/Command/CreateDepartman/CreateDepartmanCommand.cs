using Application.Features.Departmans.Dtos;
using Application.Features.Departmans.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departmans.Command.CreateDepartman
{
    public sealed class CreateDepartmanCommand : IRequest<List<CreateDepartmanDto>>
    {
        public List<string> FullNameList { get; set; }

        public class CreateDepartmanCommandHandler : IRequestHandler<CreateDepartmanCommand, List<CreateDepartmanDto>>
        {
            private readonly IDepartmanRepository _departmanRepository;
            private readonly IMapper _mapper;
            private readonly DepartmanBusinessRules _departmanBusinessRules;

            public CreateDepartmanCommandHandler(IDepartmanRepository departmanRepository, IMapper mapper, DepartmanBusinessRules departmanBusinessRules)
            {
                _departmanRepository = departmanRepository;
                _mapper = mapper;
                _departmanBusinessRules = departmanBusinessRules;
            }

            public async Task<List<CreateDepartmanDto>> Handle(CreateDepartmanCommand request, CancellationToken cancellationToken)
            {
                if (request.FullNameList == null || request.FullNameList.Count == 0)
                    await _departmanBusinessRules.DepartmanNameListCanNotBeDuplicatedWhenInserted(request.FullNameList);

                List<Departman>? mappedDepartman = request.FullNameList.Select(d => new Departman { FullName = d, CreatedDate = DateTime.Now }).ToList();
                List<Departman> addedDepartmans = await _departmanRepository.AddRangeAsync(mappedDepartman);
                List<CreateDepartmanDto> result = addedDepartmans.Select(x => new CreateDepartmanDto { Id = x.Id, FullName = x.FullName }).ToList();

                return result;
            }
        }
    }
}
