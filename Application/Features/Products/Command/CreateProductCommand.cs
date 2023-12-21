using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Mailings;
using Core.Persistence.Paging;
using Core.Security.Extensions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Products.Command
{
    public sealed class CreateProductCommand : IRequest<CreateProductDto>
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int ProductBranchId { get; set; }
        public string? ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal RegularPrice { get; set; }// Normal fiyat
        public decimal? SalePrice { get; set; }//Satış Fiyatı
        public string SKU { get; set; }//Stok Kodu
        public int Rating { get; set; }//Değerlendirme
        public int DiscountRate { get; set; }//Indirim oranı
        public int CategoryId { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductDto>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            private readonly ProductBusinnessRules _productBusinnessRules;
            private readonly IMailService _mailService;
            private readonly IHttpContextAccessor _contextAccessor;

            public CreateProductCommandHandler(IProductRepository productRepository,
                IMapper mapper, ProductBusinnessRules productBusinnessRules, IMailService mailService
                ,IHttpContextAccessor httpContextAccessor)
            {
                _contextAccessor = httpContextAccessor;
                _mailService = mailService;
                _productRepository = productRepository;
                _mapper = mapper;
                _productBusinnessRules = productBusinnessRules;
            }

            public async Task<CreateProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
               await _productBusinnessRules.CheckIfProductNameExists(request.Name);

                Product mappedProduct = _mapper.Map<Product>(request);
                Product addedProduct = await _productRepository.AddAsync(mappedProduct);
                CreateProductDto createProductDto = _mapper.Map<CreateProductDto>(addedProduct);
               await _mailService.SendMailAsync(new Mail
                {
                    ToEmail = _contextAccessor.HttpContext.User.GetEmail(),
                    HtmlBody = "<strong>Hey, Ürünlere eklendi.</strong>",
                    Subject = "Yeni ürün eklendi!",
                    ToFullName = $"{_contextAccessor.HttpContext.User.GetName()} ${_contextAccessor.HttpContext.User.GetLastName()}"
                });
                return createProductDto;
            }
        }
    }
}
