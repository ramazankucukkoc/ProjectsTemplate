using Application.Features.FindeksCreditRates.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.FindeksCreditRates.Queries.GetListFindeksCreditRate
{
    public class GetListFindeksCreditRateQuery : IRequest<GetListResponse<FindeksCreditRateDto>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListFindeksCreditRateQueryHandler : IRequestHandler<GetListFindeksCreditRateQuery, GetListResponse<FindeksCreditRateDto>>
        {
            private readonly IFindeksCreditRateRepository _findeksCreditRateRepository;
            private readonly IMapper _mapper;

            public GetListFindeksCreditRateQueryHandler(IFindeksCreditRateRepository findeksCreditRateRepository, IMapper mapper)
            {
                _findeksCreditRateRepository = findeksCreditRateRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<FindeksCreditRateDto>> Handle(GetListFindeksCreditRateQuery request, CancellationToken cancellationToken)
            {
                IPaginate<FindeksCreditRate> findeksCredirRates = await _findeksCreditRateRepository.GetListAsync(
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                GetListResponse<FindeksCreditRateDto> result = _mapper.Map<GetListResponse<FindeksCreditRateDto>>(findeksCredirRates);
                return result;
            }
        }
    }
}
