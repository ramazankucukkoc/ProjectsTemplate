using Application.Features.Countries.Dtos;
using Application.Features.Countries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Countries.Command.CreateCountry
{
    public class CreateCountryCommand : IRequest<CreateCountryDto>
    {
        public string Name { get; set; }

        public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CreateCountryDto>
        {
            private readonly ICountryRepository _countryRepository;
            private readonly IMapper _mapper;
            private readonly CountryBusinessRules _countryBusinessRules;

            public CreateCountryCommandHandler(ICountryRepository countryRepository,
                IMapper mapper, CountryBusinessRules countryBusinessRules)
            {
                _countryRepository = countryRepository;
                _mapper = mapper;
                _countryBusinessRules = countryBusinessRules;
            }

            public async Task<CreateCountryDto> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
            {
                Country? mappedCountry = _mapper.Map<Country>(request);
                Country createdCountry = await _countryRepository.AddAsync(mappedCountry);
                CreateCountryDto createCountryDto = _mapper.Map<CreateCountryDto>(createdCountry);
                return createCountryDto;
            }
        }
    }
}
