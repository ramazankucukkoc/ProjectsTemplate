using Application.Features.FindeksCreditRates.Dtos;
using Application.Features.FindeksCreditRates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FindeksCreditRates.Queries.GetByIdFindeksCreditRate
{
    public class GetByIdFindeksCreditRateQuery : IRequest<FindeksCreditRateDto>
    {
        public int Id { get; set; }

        public class GetByIdFindeksCreditRateQueryHandler : IRequestHandler<GetByIdFindeksCreditRateQuery, FindeksCreditRateDto>
        {
            private readonly IFindeksCreditRateRepository _findeksCreditRateRepository;
            private readonly IMapper _mapper;
            private readonly FindeksCreditRateBusinessRules _fadeksCreditRateBusinessRules;

            public GetByIdFindeksCreditRateQueryHandler(IFindeksCreditRateRepository findeksCreditRateRepository,
                IMapper mapper, FindeksCreditRateBusinessRules fadeksCreditRateBusinessRules)
            {
                _findeksCreditRateRepository = findeksCreditRateRepository;
                _mapper = mapper;
                _fadeksCreditRateBusinessRules = fadeksCreditRateBusinessRules;
            }

            public async Task<FindeksCreditRateDto> Handle(GetByIdFindeksCreditRateQuery request, CancellationToken cancellationToken)
            {
                await _fadeksCreditRateBusinessRules.FindeksCreditRateIdShouldExistWhenSelected(request.Id);
                FindeksCreditRate? findeksCreditRate = await _findeksCreditRateRepository.GetAsync(f => f.Id == request.Id);
                FindeksCreditRateDto findeksCreditRateDto = _mapper.Map<FindeksCreditRateDto>(findeksCreditRate);
                return findeksCreditRateDto;
            }
        }
    }
}
