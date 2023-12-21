using Application.Features.IndividualCustomers.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.IndividualCustomers.Queries.GetListIndividualCustomers
{
    public class GetListIndividualCustomerQuery : IRequest<GetListResponse<IndividualCustomerDto>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListIndividualCustomerQueryHandler : IRequestHandler<GetListIndividualCustomerQuery, GetListResponse<IndividualCustomerDto>>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;

            public GetListIndividualCustomerQueryHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<IndividualCustomerDto>> Handle(GetListIndividualCustomerQuery request, CancellationToken cancellationToken)
            {
                IPaginate<IndividualCustomer> individualCustomers = await _individualCustomerRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                if (!individualCustomers.Items.Any()) throw new NotFoundException("Müşteriler listesi bulunamadı");
                GetListResponse<IndividualCustomerDto> response = _mapper.Map<GetListResponse<IndividualCustomerDto>>(individualCustomers);
                return response;
            }
        }
    }
}
