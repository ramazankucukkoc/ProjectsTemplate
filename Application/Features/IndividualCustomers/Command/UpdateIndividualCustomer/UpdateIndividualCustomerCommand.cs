using Application.Features.IndividualCustomers.Dtos;
using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.IndividualCustomers.Command.UpdateIndividualCustomer
{
    public sealed class UpdateIndividualCustomerCommand : IRequest<UpdateIndividualCustomerDto>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }//Ulusal kimlik Uyruk diyebilriz.

        public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, UpdateIndividualCustomerDto>
        {
            private readonly IIndividualCustomerRepository _individualCustomerRepository;
            private readonly IMapper _mapper;
            private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;

            public UpdateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository,
                IMapper mapper, IndividualCustomerBusinessRules individualCustomerBusinessRules)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
                _individualCustomerBusinessRules = individualCustomerBusinessRules;
            }

            public Task<UpdateIndividualCustomerDto> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
