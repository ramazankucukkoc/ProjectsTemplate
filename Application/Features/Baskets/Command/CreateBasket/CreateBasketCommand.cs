using Application.Features.Baskets.Dtos;
using Application.Features.Baskets.Rules;
using Application.Services.ProductService;
using Application.Services.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Core.Domain.Entities;
using Core.Mailings;
using Domain.Entities;
using MediatR;

namespace Application.Features.Baskets.Command.CreateBasket
{
    public class CreateBasketCommand : IRequest<CreateBasketDto>
    {
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int UserId { get; set; }
        public int Count { get; set; }

        public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, CreateBasketDto>
        {
            private readonly IBasketRepository _basketRepository;
            private readonly IMapper _mapper;
            private readonly BasketBusinessRules _basketBusinessRules;
            private readonly IMailService _mailService;
            private readonly IUserService _userService;
            private readonly IProductService _productService;

            public CreateBasketCommandHandler(IBasketRepository basketRepository, IMapper mapper, BasketBusinessRules basketBusinessRules, IMailService mailService,
                IUserService userService,IProductService productService)
            {
                _basketRepository = basketRepository;
                _mapper = mapper;
                _basketBusinessRules = basketBusinessRules;
                _mailService = mailService;
                _userService = userService;
                _productService = productService;
            }

            public async Task<CreateBasketDto> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
            {
                User? user =await _userService.GetById(request.UserId);
                Product product = await _productService.GetById(request.ProductId);
                Basket? mappedBasket = _mapper.Map<Basket>(request);
                Basket createBasket = await _basketRepository.AddAsync(mappedBasket);
                CreateBasketDto createBasketDto = _mapper.Map<CreateBasketDto>(createBasket);

                await _mailService.SendMailAsync(new Mail
                {
                    ToEmail =user.Email,
                    ToFullName=$"{user.FirstName} ${user.LastName}",
                    Subject = "Register Your Email - ECommerce - Ramazan",
                    TextBody = "Teşekkürler",
                    HtmlBody = $"Sepete {product.Name} ürün<strong> başarılı şekilde eklendi.</strong>"

                });
                return createBasketDto;
            }
        }
    }
}
