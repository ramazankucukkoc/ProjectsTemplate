﻿using Application.Features.CorporateCustomers.Dtos;
using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CorporateCustomers.Command.DeleteCorporateCustomer
{
    public class DeleteCorporateCustomerCommand : IRequest<DeleteCorporateCustomerDto>
    {
        public int Id { get; set; }

        public class DeleteCorporateCustomerCommandHandler : IRequestHandler<DeleteCorporateCustomerCommand, DeleteCorporateCustomerDto>
        {
            private readonly ICorporateCustomerRepository _corporateCustomerRepository;
            private readonly IMapper _mapper;
            private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;

            public DeleteCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository
                , IMapper mapper, CorporateCustomerBusinessRules corporateCustomerBusinessRules)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
                _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
            }

            public async Task<DeleteCorporateCustomerDto> Handle(DeleteCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                await _corporateCustomerBusinessRules.CorporateCustomerIdShouldExistWhenSelected(request.Id);
                CorporateCustomer? mappedCorporateCustomer = _mapper.Map<CorporateCustomer>(request);
                CorporateCustomer deletedCorporateCustomer = await _corporateCustomerRepository.DeleteAsync(mappedCorporateCustomer);

                DeleteCorporateCustomerDto deleteCorporateCustomerDto = _mapper.Map<DeleteCorporateCustomerDto>(deletedCorporateCustomer);
                return deleteCorporateCustomerDto;
            }
        }
    }
}
