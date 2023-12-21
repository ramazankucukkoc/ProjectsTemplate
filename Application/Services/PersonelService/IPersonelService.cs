using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Services.PersonelService
{
    public interface IPersonelService
    {
        Task<Personel> GetByName(string firstName, string lastName);
        Task<Personel> AddAsync(Personel personel);
        Task<Personel> RemoveAsync(Personel personel);
        Task<IPaginate<Personel>> GetAllAsync(int index = 0, int size = 10, CancellationToken cancellationToken = default);
        Task Remove(Personel personel);
        Task Add(Personel personel);

    }
}
