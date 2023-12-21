using Application.Features.ProductComments.Dtos;
using Application.Features.ProductComments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductComments.Command.CreateProductComment
{
    public sealed class CreateProductCommentCommand : IRequest<CreateProductCommentDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }

        public class CreateProductCommentCommandHandler : IRequestHandler<CreateProductCommentCommand, CreateProductCommentDto>
        {
            private readonly IProductCommentRepository _productCommentRepository;
            private readonly IMapper _mapper;
            private readonly ProductCommentBusinessRules _productCommentBusinessRules;

            public CreateProductCommentCommandHandler(IProductCommentRepository productCommentRepository, IMapper mapper,
                ProductCommentBusinessRules productCommentBusinessRules)
            {
                _productCommentRepository = productCommentRepository;
                _mapper = mapper;
                _productCommentBusinessRules = productCommentBusinessRules;
            }

            public async Task<CreateProductCommentDto> Handle(CreateProductCommentCommand request, CancellationToken cancellationToken)
            {
                ProductComment? mappedProductComment = _mapper.Map<ProductComment>(request);
                ProductComment createdProductComment = await _productCommentRepository.AddAsync(mappedProductComment);
                CreateProductCommentDto result = _mapper.Map<CreateProductCommentDto>(createdProductComment);
                return result;
            }
        }


    }
}
