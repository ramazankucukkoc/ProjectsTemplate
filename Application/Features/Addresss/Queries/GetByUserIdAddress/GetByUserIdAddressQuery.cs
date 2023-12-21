using Application.Features.Addresss.Dtos;
using Application.Features.Addresss.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Addresss.Queries.GetByUserIdAddress
{
    public class GetByUserIdAddressQuery : IRequest<GetListResponse<GetByUserIdAddressDto>>
    {
        public PageRequest PageRequest { get; set; }
        public int UserId { get; set; }
        public class GetByUserIdAddressQueryHandler : IRequestHandler<GetByUserIdAddressQuery, GetListResponse<GetByUserIdAddressDto>>
        {
            private readonly IAddressRepository _addressRepository;
            private readonly AddressBusinessRules _addressBusinessRules;
            private readonly IMapper _mapper;


            public GetByUserIdAddressQueryHandler(IAddressRepository addressRepository, AddressBusinessRules addressBusinessRules, IMapper mapper)
            {
                _mapper = mapper;
                _addressRepository = addressRepository;
                _addressBusinessRules = addressBusinessRules;
            }

            public async Task<GetListResponse<GetByUserIdAddressDto>> Handle(GetByUserIdAddressQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GetByUserIdAddressDto> result = await _addressRepository.GetByUserIdAddressAsync(request.UserId, request.PageRequest.Page, request.PageRequest.PageSize, cancellationToken);
                GetListResponse<GetByUserIdAddressDto> response = _mapper.Map<GetListResponse<GetByUserIdAddressDto>>(result);
                return response;
            }
        }
    }
}
