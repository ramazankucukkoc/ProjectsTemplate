using Application.Features.ProductComments.Dtos;
using Application.Features.ProductComments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductComments.Command.UpdateProductComment
{
    public sealed class UpdateProductCommentCommand : IRequest<UpdateProductCommentDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }

        public class UpdateProductCommentCommandHandler : IRequestHandler<UpdateProductCommentCommand, UpdateProductCommentDto>
        {
            private readonly IProductCommentRepository _productCommentRepository;
            private readonly IMapper _mapper;
            private readonly ProductCommentBusinessRules _businessRules;

            public UpdateProductCommentCommandHandler(IProductCommentRepository productCommentRepository,
                IMapper mapper, ProductCommentBusinessRules businessRules)
            {
                _productCommentRepository = productCommentRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<UpdateProductCommentDto> Handle(UpdateProductCommentCommand request, CancellationToken cancellationToken)
            {
                ProductComment? productComment = _mapper.Map<ProductComment>(request);
                ProductComment updatedProductComment = await _productCommentRepository.UpdateAsync(productComment);
                UpdateProductCommentDto result = _mapper.Map<UpdateProductCommentDto>(updatedProductComment);
                return result;
            }
        }
    }
}
