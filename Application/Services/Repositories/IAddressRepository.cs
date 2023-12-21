using Application.Features.Addresss.Dtos;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IAddressRepository : IAsyncRepository<Address>
    {
        Task<IPaginate<GetByUserIdAddressDto>> GetByUserIdAddressAsync(int userId, int index = 0, int size = 10, CancellationToken cancellationToken = default);


    }
}
