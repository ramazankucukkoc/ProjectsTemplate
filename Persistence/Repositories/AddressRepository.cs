using Application.Features.Addresss.Dtos;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class AddressRepository : EfRepositoryBase<Address, ProjectDbContext>, IAddressRepository
    {
        public AddressRepository(ProjectDbContext context) : base(context)
        {
        }

        public async Task<IPaginate<GetByUserIdAddressDto>> GetByUserIdAddressAsync(int userId, int index = 0, int size = 10, CancellationToken cancellationToken = default)
        {
            IQueryable<GetByUserIdAddressDto> result = from a in Context.Addresses
                                                       join u in Context.Users
                                                       on a.UserId equals u.Id
                                                       join c in Context.Cities
                                                       on a.CityId equals c.Id
                                                       where u.Id == userId
                                                       select new GetByUserIdAddressDto
                                                       {
                                                           CityId = c.Id,
                                                           UserId = u.Id,
                                                           AddressAbbreviation = a.AddressAbbreviation,
                                                           AddressDetail = a.AddressDetail,
                                                           CityName = c.Name,
                                                           Email = u.Email,
                                                           PostalCode = a.PostalCode,
                                                           UserName = u.FirstName + " " + u.LastName
                                                       };
            return await result.ToPaginateAsync(index: index, size: size, 0, cancellationToken);


        }
    }
}
