using Application.Features.IndividualCustomers.Dtos;
using Application.Features.IndividualCustomers.Rules;
using Application.Services.FindeksCreditRateService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.IndividualCustomers.Command.DeleteIndividualCustomer
{
    public class DeleteIndividualCustomerCommand : IRequest<DeleteIndividualCustomerDto>
    {
        public int Id { get; set; }


        public class DeleteIndividualCustomerCommandHandler : IRequestHandler<DeleteIndividualCustomerCommand, DeleteIndividualCustomerDto>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;
            private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;
            private readonly IFindeksCreditRateService _findeksCreditRateService;

            public DeleteIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper,
                IndividualCustomerBusinessRules individualCustomerBusinessRules,
                IFindeksCreditRateService findeksCreditRateService)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
                _individualCustomerBusinessRules = individualCustomerBusinessRules;
                _findeksCreditRateService = findeksCreditRateService;
            }

            public async Task<DeleteIndividualCustomerDto> Handle(DeleteIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                await _individualCustomerBusinessRules.IndividualCustomerIdShouldExistWhenSelected(request.Id);
                IndividualCustomer individualCustomer = await _individualCustomerRepository.GetAsync(i => i.Id == request.Id);
                individualCustomer.Active = false;

                IndividualCustomer deletedIndividualCustomer = await _individualCustomerRepository.UpdateAsync(individualCustomer);
                DeleteIndividualCustomerDto result = _mapper.Map<DeleteIndividualCustomerDto>(deletedIndividualCustomer);
                return result;
            }
        }
    }
}
