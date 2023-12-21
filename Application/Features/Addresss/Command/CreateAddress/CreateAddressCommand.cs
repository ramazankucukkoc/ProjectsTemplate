using Application.Features.Addresss.Dtos;
using Application.Features.Addresss.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Addresss.Command.CreateAddress
{
    public class CreateAddressCommand : IRequest<CreateAddressDto>, ISecuredRequest, ILoggableRequest
    {
        public int UserId { get; set; }
        public int CityId { get; set; }
        public string AddressDetail { get; set; }
        public string AddressAbbreviation { get; set; }//Adres Kısaltması
        public string PostalCode { get; set; }

        public string[] Roles => new[] { RoleNames.AddressAdmin };

        public class CreateBrandCommandHandler : IRequestHandler<CreateAddressCommand, CreateAddressDto>
        {
            private readonly IAddressRepository _addressRepository;
            private readonly IMapper _mapper;
            private readonly AddressBusinessRules _addressBusinessRules;

            public CreateBrandCommandHandler(IAddressRepository addressRepository,
                IMapper mapper, AddressBusinessRules addressBusinessRules)
            {
                _addressRepository = addressRepository;
                _mapper = mapper;
                _addressBusinessRules = addressBusinessRules;
            }

            public async Task<CreateAddressDto> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
            {
                Address? mappedAddress = _mapper.Map<Address>(request);
                Address createAddress = await _addressRepository.AddAsync(mappedAddress);
                CreateAddressDto createAddressDto = _mapper.Map<CreateAddressDto>(createAddress);
                return createAddressDto;
            }
        }
    }
}
