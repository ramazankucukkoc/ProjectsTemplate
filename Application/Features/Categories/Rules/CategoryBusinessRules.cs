using Application.Features.Categories.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Categories.Rules
{
    public class CategoryBusinessRules
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryBusinessRules(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task CategoryNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Category> categories = await _categoryRepository.GetListAsync(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
            if (categories.Items.Any()) throw new BusinessException(CategoryExceptionMessages.CategoryNameExists);
        }
        public async Task CategoryCanNotBeDuplicatedWhenInserted(int id)
        {
            Category? category = await _categoryRepository.GetAsync(x => x.Id == id);
            if (category == null) throw new BusinessException(CategoryExceptionMessages.CategoryExists);
        }

    }
}
