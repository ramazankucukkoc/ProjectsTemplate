using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Services.BrandService
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandManager(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Brand> GetById(int id)
        {
            Brand? brand = await _brandRepository.GetAsync(b => b.Id == id);
            return brand;
        }

        public async Task<Brand> GetByName(string name)
        {
            Brand? brand = await _brandRepository.GetAsync(b => b.Name.ToLower() == name.ToLower());
            return brand;

        }
    }
}
