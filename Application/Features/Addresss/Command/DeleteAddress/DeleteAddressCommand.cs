using Application.Features.Addresss.Dtos;
using Application.Features.Addresss.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Addresss.Command.DeleteAddress
{
    public class DeleteAddressCommand : IRequest<DeleteAddressDto>, ISecuredRequest, ILoggableRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { RoleNames.AddressAdmin };

        public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, DeleteAddressDto>
        {
            private readonly IAddressRepository _addressRepository;
            private readonly IMapper _mapper;
            private readonly AddressBusinessRules _addressBusinessRules;

            public DeleteAddressCommandHandler(IAddressRepository addressRepository,
                IMapper mapper, AddressBusinessRules addressBusinessRules)
            {
                _addressRepository = addressRepository;
                _mapper = mapper;
                _addressBusinessRules = addressBusinessRules;
            }
            public async Task<DeleteAddressDto> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
            {
                await _addressBusinessRules.AddressIdShoulExistsWhenInserted(request.Id);
                Address? getByIdAddress = await _addressRepository.GetAsync(a => a.Id == request.Id);
                getByIdAddress.Active = false;
                Address deletedAddress = await _addressRepository.UpdateAsync(getByIdAddress);
                DeleteAddressDto deleteAddressDto = _mapper.Map<DeleteAddressDto>(deletedAddress);
                return deleteAddressDto;

            }
        }
    }
}
