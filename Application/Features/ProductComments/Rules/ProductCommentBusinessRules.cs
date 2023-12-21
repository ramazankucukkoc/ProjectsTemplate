using Application.Services.Repositories;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;
using Domain.Entities;

namespace Application.Features.ProductComments.Rules
{
    public class ProductCommentBusinessRules
    {
        private readonly IProductCommentRepository _productCommentRepository;

        public ProductCommentBusinessRules(IProductCommentRepository productCommentRepository)
        {
            _productCommentRepository = productCommentRepository;
        }
        public async Task ProductCommentIdControl(int id)
        {
            ProductComment? productComment = await _productCommentRepository.GetAsync(p => p.Id == id);
            if (productComment == null) throw new BusinessException($"{id}'ye ait ürün yorumu yoktur ");
        }

    }
}
