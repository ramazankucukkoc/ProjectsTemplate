using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ParentCategories.Rules
{
    public class ParentCategoriesBusinessRules
    {
        private readonly IParentCategoryRepository _parentCategoryRepository;

        public ParentCategoriesBusinessRules(IParentCategoryRepository parentCategoryRepository)
        {
            _parentCategoryRepository = parentCategoryRepository;
        }

        public async Task ParentCategoryNameCanNotBeDuplicatedWhenInserted(string parentCategoryName)
        {
            IPaginate<ParentCategory> parentCategory = await _parentCategoryRepository.GetListAsync(p => p.Name.Trim().ToLower() == parentCategoryName.Trim().ToLower());
            if (parentCategory.Items.Any()) throw new BusinessException("Bu alt kategori eklidir bir daha eklenemez");
        }
    }
}
