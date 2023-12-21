using Application.Features.FindeksCreditRates.Dtos;
using Application.Services.FindeksCreditRateService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FindeksCreditRates.Command.UpdateFindeksCreditRateFromService
{
    public class UpdateFindeksCreditRateFromServiceCommand : IRequest<UpdateFindeksCreditRateDto>
    {
        public int Id { get; set; }
        public string IdentityNumber { get; set; }

        public class UpdateFindeksCreditRateFromServiceCommandHandler : IRequestHandler<UpdateFindeksCreditRateFromServiceCommand, UpdateFindeksCreditRateDto>
        {
            private readonly IFindeksCreditRateRepository _findeksCreditRateRepository;
            private readonly IFindeksCreditRateService _findeksCreditRateService;
            private readonly IMapper _mapper;

            public UpdateFindeksCreditRateFromServiceCommandHandler(IFindeksCreditRateRepository findeksCreditRateRepository,
                IFindeksCreditRateService findeksCreditRateService, IMapper mapper)
            {
                _findeksCreditRateRepository = findeksCreditRateRepository;
                _findeksCreditRateService = findeksCreditRateService;
                _mapper = mapper;
            }

            public async Task<UpdateFindeksCreditRateDto> Handle(UpdateFindeksCreditRateFromServiceCommand request, CancellationToken cancellationToken)
            {
                FindeksCreditRate? findeksCreditRate = await _findeksCreditRateRepository.GetAsync(f => f.Id == request.Id);
                findeksCreditRate.Score = _findeksCreditRateService.GetScore(request.IdentityNumber);
                FindeksCreditRate updatedFindekCreditRate = await _findeksCreditRateRepository.UpdateAsync(findeksCreditRate);

                UpdateFindeksCreditRateDto updateFindeksCreditRateDto = _mapper.Map<UpdateFindeksCreditRateDto>(updatedFindekCreditRate);
                return updateFindeksCreditRateDto;

            }
        }
    }
}
