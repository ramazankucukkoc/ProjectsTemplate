using Application.Features.Customers.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Customers.Queries.GetListCustomer
{
    public class GetListCustomerQuery : IRequest<GetListResponse<CustomerDto>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListCustomerQueryHandler : IRequestHandler<GetListCustomerQuery, GetListResponse<CustomerDto>>
        {
            private readonly IMapper _mapper;
            private readonly ICustomerRepository _customerRepository;

            public GetListCustomerQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
            {
                _mapper = mapper;
                _customerRepository = customerRepository;
            }

            public async Task<GetListResponse<CustomerDto>> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Customer> customers = await _customerRepository.GetListAsync(index: request.PageRequest.Page,
                                                               size: request.PageRequest.PageSize,
                                                               include: u => u.Include(u => u.User));
                if (customers.Items.Any() == false) throw new NotFoundException("Müşteriler bulunmadı");

                GetListResponse<CustomerDto> mappedCustomerListModel = _mapper.Map<GetListResponse<CustomerDto>>(customers);
                return mappedCustomerListModel;
            }
        }
    }
}
