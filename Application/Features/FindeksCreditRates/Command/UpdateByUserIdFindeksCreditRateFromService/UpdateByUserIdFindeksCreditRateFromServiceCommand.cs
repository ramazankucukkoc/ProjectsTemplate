using Application.Features.FindeksCreditRates.Dtos;
using Application.Features.FindeksCreditRates.Rules;
using Application.Services.CustomerService;
using Application.Services.FindeksCreditRateService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FindeksCreditRates.Command.UpdateByUserIdFindeksCreditRateFromService
{
    public class UpdateByUserIdFindeksCreditRateFromServiceCommand : IRequest<UpdateFindeksCreditRateDto>
    {
        public int UserId { get; set; }
        public string IdentityNumber { get; set; }

        public class UpdateByUserIdFindeksCreditRateFromServiceCommandHandler : IRequestHandler<UpdateByUserIdFindeksCreditRateFromServiceCommand, UpdateFindeksCreditRateDto>
        {
            private readonly IFindeksCreditRateRepository _findeksCreditRateRepository;
            private readonly IFindeksCreditRateService _findeksCreditRateService;
            private readonly IMapper _mapper;
            private readonly FindeksCreditRateBusinessRules _findeksCreditRateBusinessRules;
            private readonly ICustomerService _customerService;
            public UpdateByUserIdFindeksCreditRateFromServiceCommandHandler(IFindeksCreditRateRepository findeksCreditRateRepository, IFindeksCreditRateService findeksCreditRateService,
                IMapper mapper, FindeksCreditRateBusinessRules findeksCreditRateBusinessRules, ICustomerService customerService)
            {
                _findeksCreditRateRepository = findeksCreditRateRepository;
                _findeksCreditRateService = findeksCreditRateService;
                _mapper = mapper;
                _findeksCreditRateBusinessRules = findeksCreditRateBusinessRules;
                _customerService = customerService;
            }

            public async Task<UpdateFindeksCreditRateDto> Handle(UpdateByUserIdFindeksCreditRateFromServiceCommand request, CancellationToken cancellationToken)
            {
                Customer? customer = await _customerService.GetByUserId(request.UserId);
                FindeksCreditRate? findeksCreditRate = await _findeksCreditRateRepository.GetAsync(f => f.CustomerId == customer.Id);
                findeksCreditRate.Score = _findeksCreditRateService.GetScore(request.IdentityNumber);
                FindeksCreditRate updatedFindeksCreditRate = await _findeksCreditRateRepository.UpdateAsync(findeksCreditRate);
                UpdateFindeksCreditRateDto result = _mapper.Map<UpdateFindeksCreditRateDto>(updatedFindeksCreditRate);
                return result;
            }
        }
    }
}
