using Application.Features.Personels.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Personels.Rules
{
    public class PersonelBusinessRules
    {
        private readonly IPersonelRepository _personelRepository;

        public PersonelBusinessRules(IPersonelRepository personelRepository)
        {
            _personelRepository = personelRepository;
        }
        public async Task PersonelNameCanNotBeDuplicatedWhenInserted(string personelName)
        {
            IPaginate<Personel> result = await _personelRepository.GetListAsync(p => p.FirstName + " " + p.LastName == personelName);
            if (result.Items.Any()) throw new BusinessException(PersonelBusinessException.PersonelFullName);
        }
        public async Task PersonelIdControl(int id)
        {
            Personel? getByIdPersonel = await _personelRepository.GetAsync(p => p.Id == id);
            if (getByIdPersonel is null) throw new BusinessException(PersonelBusinessException.PersonelIdDonotExists);
        }
    }
}
