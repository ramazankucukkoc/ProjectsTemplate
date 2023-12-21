using Application.Features.FindeksCreditRates.Dtos;
using Application.Features.FindeksCreditRates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.FindeksCreditRates.Command.CreateFindeksCreditRate
{
    public class CreateFindeksCreditRateCommand : IRequest<CreateFindeksCreditRateDto>
    {
        //Findeks Kredi Notu; kişilerin kredi, kredi kartı ve kredili mevduat hesaplarındaki ödeme alışkanlıklarına,
        //limit ve borç durumlarına, yeni kredili ürün açılışlarının yoğunluğu gibi detaylara göre hesaplanan nottur.
        //Findeks Kredi Notu 1-1900 arasında değişir. Not 1'den 1900'e doğru ilerledikçe risk seviyesi azalır.
        public int CustomerId { get; set; }
        public int Score { get; set; }

        public class CreateFindeksCreditRateCommandHandler : IRequestHandler<CreateFindeksCreditRateCommand, CreateFindeksCreditRateDto>
        {
            private readonly IFindeksCreditRateRepository _findeksCreditRateRepository;
            private readonly IMapper _mapper;
            private readonly FindeksCreditRateBusinessRules _fadeksCreditRateBusinessRules;

            public CreateFindeksCreditRateCommandHandler(IFindeksCreditRateRepository findeksCreditRateRepository,
                IMapper mapper, FindeksCreditRateBusinessRules fadeksCreditRateBusinessRules)
            {
                _findeksCreditRateRepository = findeksCreditRateRepository;
                _mapper = mapper;
                _fadeksCreditRateBusinessRules = fadeksCreditRateBusinessRules;
            }

            public async Task<CreateFindeksCreditRateDto> Handle(CreateFindeksCreditRateCommand request, CancellationToken cancellationToken)
            {
                FindeksCreditRate mappedFindeksCreditRate = _mapper.Map<FindeksCreditRate>(request);
                FindeksCreditRate createdFindeksCredidRate = await _findeksCreditRateRepository.AddAsync(mappedFindeksCreditRate);
                CreateFindeksCreditRateDto result = _mapper.Map<CreateFindeksCreditRateDto>(createdFindeksCredidRate);
                return result;
            }

        }
    }
}
