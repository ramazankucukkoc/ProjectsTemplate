using Application.Features.Brands.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task BrandIdShoulExistsWhenInserted(int id)
        {
            Brand? result = await _brandRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException(BusinessRulesExceptionMessages.BrandNotExists);
        }
        public async Task BrandActiveShoulExistsWhenInserted(bool active)
        {
            if (active == false) throw new BusinessException(BusinessRulesExceptionMessages.BrandNotExists);
        }
        public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Brand> result = await _brandRepository.GetListAsync(b => b.Name.ToLower().Trim() == name.ToLower());
            if (result.Items.Any()) throw new BusinessException(BusinessRulesExceptionMessages.BrandNameExists);
        }
        public async Task BrandNameListCanNotBeDuplicatedWhenInserted(List<string> nameList)
        {
            IPaginate<Brand> result = await _brandRepository.GetListAsync(b => nameList.Contains(b.Name));
            if (result.Items.Any()) throw new BusinessException(BusinessRulesExceptionMessages.BrandNameExists);
        }

    }
}
