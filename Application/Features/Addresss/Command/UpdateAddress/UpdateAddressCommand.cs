using Application.Features.Addresss.Dtos;
using Application.Features.Addresss.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Addresss.Command.UpdateAddress
{
    public class UpdateAddressCommand : IRequest<UpdateAddressDto>, ISecuredRequest, ILoggableRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
        public string AddressDetail { get; set; }
        public string AddressAbbreviation { get; set; }//Adres Kısaltması
        public string PostalCode { get; set; }
        public string[] Roles => new[] { RoleNames.AddressAdmin };

        public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, UpdateAddressDto>
        {
            private readonly IAddressRepository _addressRepository;
            private readonly IMapper _mapper;
            private readonly AddressBusinessRules _addressBusinessRules;

            public UpdateAddressCommandHandler(IAddressRepository addressRepository,
                IMapper mapper, AddressBusinessRules addressBusinessRules)
            {
                _addressRepository = addressRepository;
                _mapper = mapper;
                _addressBusinessRules = addressBusinessRules;
            }

            public async Task<UpdateAddressDto> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
            {
                await _addressBusinessRules.AddressIdShoulExistsWhenInserted(request.Id);
                Address? getByIdAddress = await _addressRepository.GetAsync(a => a.Id == request.Id);
                await _addressBusinessRules.AddressActiveShoulExistsWhenInserted(getByIdAddress.Active);
                Address mappedAddress = _mapper.Map<Address>(request);
                Address updatedAddress = await _addressRepository.UpdateAsync(mappedAddress);
                UpdateAddressDto updateAddressDto = _mapper.Map<UpdateAddressDto>(updatedAddress);
                return updateAddressDto;
            }
        }
    }
}
