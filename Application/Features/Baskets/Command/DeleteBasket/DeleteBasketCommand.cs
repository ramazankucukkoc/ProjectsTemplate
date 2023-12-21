using Application.Features.Baskets.Dtos;
using Application.Features.Baskets.Rules;
using Application.Services.Repositories;
using Application.Services.UserService;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Baskets.Command.DeleteBasket
{
    public sealed class DeleteBasketCommand : IRequest<DeleteBasketDto>
    {
        public int Id { get; set; }
        public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand, DeleteBasketDto>
        {
            private readonly IBasketRepository _basketRepository;
            private readonly IMapper _mapper;
            private readonly IUserService _userService;
            private readonly BasketBusinessRules _basketBusinessRules;

            public DeleteBasketCommandHandler(IBasketRepository basketRepository, IMapper mapper, IUserService userService, BasketBusinessRules basketBusinessRules)
            {
                _basketRepository = basketRepository;
                _mapper = mapper;
                _userService = userService;
                _basketBusinessRules = basketBusinessRules;
            }

            public async Task<DeleteBasketDto> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
            {
                await _basketBusinessRules.BasketIdControl(request.Id);
                Basket? basket = await _basketRepository.GetAsync(b => b.Id == request.Id,
                    include: b => b.Include(b => b.Brand).Include(b => b.Product).Include(b => b.User));
                basket.Active = false;
                Basket deletedBasket = await _basketRepository.UpdateAsync(basket);
                DeleteBasketDto deleteBasketDto = _mapper.Map<DeleteBasketDto>(deletedBasket);
                return deleteBasketDto;
            }
        }

    }
}
