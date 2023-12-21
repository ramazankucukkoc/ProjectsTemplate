using Application.Features.IndividualCustomers.Dtos;
using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.IndividualCustomers.Command.CreateIndividualCustomer
{
    public sealed class CreateIndividualCustomerCommand : IRequest<CreateIndividualCustomerDto>
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }//Ulusal kimlik Uyruk diyebilriz.

        public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreateIndividualCustomerDto>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;
            private readonly IFindeksCreditRateRepository _findeksCreditRateRepository;
            private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;

            public CreateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository,
                IMapper mapper, IFindeksCreditRateRepository findeksCreditRateRepository, IndividualCustomerBusinessRules individualCustomerBusinessRules)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
                _findeksCreditRateRepository = findeksCreditRateRepository;
                _individualCustomerBusinessRules = individualCustomerBusinessRules;
            }

            public async Task<CreateIndividualCustomerDto> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                await _individualCustomerBusinessRules.IndividualCustomerNationalIdentityCanNotBeDuplicatedWhenInserted(request.NationalIdentity);
                IndividualCustomer mappedIndividualCustomer = _mapper.Map<IndividualCustomer>(request);
                IndividualCustomer createdIndividualCustomer = await _individualCustomerRepository.AddAsync(mappedIndividualCustomer);

                await _findeksCreditRateRepository.AddAsync(new FindeksCreditRate { CustomerId = createdIndividualCustomer.CustomerId });

                CreateIndividualCustomerDto result = _mapper.Map<CreateIndividualCustomerDto>(createdIndividualCustomer);
                return result;
            }
        }
    }
}
