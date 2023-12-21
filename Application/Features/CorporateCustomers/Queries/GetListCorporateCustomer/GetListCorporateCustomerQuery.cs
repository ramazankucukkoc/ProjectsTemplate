using Application.Features.CorporateCustomers.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.CorporateCustomers.Queries.GetListCorporateCustomer
{
    public class GetListCorporateCustomerQuery : IRequest<GetListResponse<CorporateCustomerDto>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListCorporateCustomerQueryHandler : IRequestHandler<GetListCorporateCustomerQuery, GetListResponse<CorporateCustomerDto>>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;

            public GetListCorporateCustomerQueryHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<CorporateCustomerDto>> Handle(GetListCorporateCustomerQuery request, CancellationToken cancellationToken)
            {
                IPaginate<CorporateCustomer> corporateCustomers = await _corporateCustomerRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                if (corporateCustomers.Items.Any() == false) throw new NotFoundException("Müşteriler bulunamadı");

                GetListResponse<CorporateCustomerDto> result = _mapper.Map<GetListResponse<CorporateCustomerDto>>(corporateCustomers);
                return result;
            }
        }
    }
}
