using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Services.PersonelService
{
    public class PersonelManager : IPersonelService
    {
        private readonly IPersonelRepository _personelRepository;

        public PersonelManager(IPersonelRepository personelRepository)
        {
            _personelRepository = personelRepository;
        }

        public async Task Add(Personel personel)
        {
            await _personelRepository.AddAsync(personel);
        }

        public async Task<Personel> AddAsync(Personel personel)
        {
            Personel? addedPersonel = await _personelRepository.AddAsync(personel);
            return addedPersonel;
        }

        public async Task<IPaginate<Personel>> GetAllAsync(int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            IPaginate<Personel> result = await _personelRepository.GetListAsync(index: index, size: size);
            return result;
        }

        public async Task<Personel> GetByName(string firstName, string lastName)
        {
            Personel? personel = await _personelRepository.GetAsync(p => p.FirstName.ToLower().Trim() == firstName.ToLower().Trim()
            && p.LastName.ToLower().Trim() == lastName.ToLower().Trim());
            return personel;
        }

        public async Task Remove(Personel personel)
        {
            await _personelRepository.DeleteAsync(personel);
        }

        public async Task<Personel> RemoveAsync(Personel personel)
        {
            Personel? removePersonel = await _personelRepository.DeleteAsync(personel);
            return removePersonel;
        }
    }
}
