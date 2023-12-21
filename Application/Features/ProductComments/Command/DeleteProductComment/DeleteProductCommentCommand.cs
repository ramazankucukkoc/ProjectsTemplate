using Application.Features.ProductComments.Dtos;
using Application.Features.ProductComments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductComments.Command.DeleteProductComment
{
    public sealed class DeleteProductCommentCommand : IRequest<DeleteProductCommentDto>
    {
        public int Id { get; set; }

        public class DeleteProductCommentCommandHandler : IRequestHandler<DeleteProductCommentCommand, DeleteProductCommentDto>
        {
            private readonly IProductCommentRepository _productCommentRepository;
            private readonly IMapper _mapper;
            private readonly ProductCommentBusinessRules _businessRules;

            public DeleteProductCommentCommandHandler(IProductCommentRepository productCommentRepository, IMapper mapper, ProductCommentBusinessRules businessRules)
            {
                _productCommentRepository = productCommentRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<DeleteProductCommentDto> Handle(DeleteProductCommentCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.ProductCommentIdControl(request.Id);
                ProductComment? getByIdProductComment = await _productCommentRepository.GetAsync(p => p.Id == request.Id);
                ProductComment deletedProductComment = await _productCommentRepository.DeleteAsync(getByIdProductComment);
                DeleteProductCommentDto result = _mapper.Map<DeleteProductCommentDto>(deletedProductComment);
                return result;
            }
        }


    }
}
