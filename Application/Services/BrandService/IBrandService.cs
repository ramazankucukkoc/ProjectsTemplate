using Domain.Entities;

namespace Application.Services.BrandService
{
    public interface IBrandService
    {
        Task<Brand> GetById(int id);
        Task<Brand> GetByName(string name);
    }
}
