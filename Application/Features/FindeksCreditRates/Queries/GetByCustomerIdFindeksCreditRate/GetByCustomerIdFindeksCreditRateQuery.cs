using Application.Features.FindeksCreditRates.Dtos;
using Application.Features.FindeksCreditRates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FindeksCreditRates.Queries.GetByCustomerIdFindeksCreditRate
{
    public class GetByCustomerIdFindeksCreditRateQuery : IRequest<FindeksCreditRateDto>
    {
        public int CustomerId { get; set; }

        public class GetByIdFindeksCreditRateQueryHasndler : IRequestHandler<GetByCustomerIdFindeksCreditRateQuery, FindeksCreditRateDto>
        {
            private readonly IFindeksCreditRateRepository _findeksCreditRateRepository;
            private readonly IMapper _mapper;
            private readonly FindeksCreditRateBusinessRules _fadeksCreditRateBusinessRules;

            public GetByIdFindeksCreditRateQueryHasndler(IFindeksCreditRateRepository findeksCreditRateRepository,
                IMapper mapper, FindeksCreditRateBusinessRules fadeksCreditRateBusinessRules)
            {
                _findeksCreditRateRepository = findeksCreditRateRepository;
                _mapper = mapper;
                _fadeksCreditRateBusinessRules = fadeksCreditRateBusinessRules;
            }

            public async Task<FindeksCreditRateDto> Handle(GetByCustomerIdFindeksCreditRateQuery request, CancellationToken cancellationToken)
            {
                FindeksCreditRate? findeksCreditRate = await _findeksCreditRateRepository.GetAsync(c => c.CustomerId == request.CustomerId);
                await _fadeksCreditRateBusinessRules.FindeksCreditShouldBeExist(findeksCreditRate);
                FindeksCreditRateDto findeksCreditRateDto = _mapper.Map<FindeksCreditRateDto>(findeksCreditRate);
                return findeksCreditRateDto;
            }
        }
    }
}
