using Application.Features.Baskets.Command.CreateBasket;
using Application.Features.Baskets.Command.DeleteBasket;
using Application.Features.Baskets.Command.UpdateBasket;
using Application.Features.Baskets.Dtos;
using Application.Features.Baskets.Queries.GetByBrandIdBasket;
using Application.Features.Baskets.Queries.GetByProductIdBasket;
using Application.Features.Baskets.Queries.GetList;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBasketCommandModelDto createBasketCommandModelDto)
        {
            CreateBasketCommand createBasketCommand = new()
            {
                BrandId = createBasketCommandModelDto.BrandId,
                ProductId = createBasketCommandModelDto.ProductId,
                Count = createBasketCommandModelDto.Count,
                UserId = getUserIdFromRequest()
            };

            CreateBasketDto result = await Mediator.Send(createBasketCommand);
            return Ok(result);
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBasketCommand deleteBasketCommand)
        {
            DeleteBasketDto result = await Mediator.Send(deleteBasketCommand);
            return Ok(result);
        }

        [HttpGet]
        [Route("{BrandId}")]
        public async Task<IActionResult> GetByBrandIdBasket([FromRoute] GetByBrandIdBasketQuery getByBrandIdBasketQuery)
        {
            GetListResponse<GetByBrandIdBasketDto> result = await Mediator.Send(getByBrandIdBasketQuery);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBasketCommand updateBasketCommand)
        {
            UpdateBasketDto result = await Mediator.Send(updateBasketCommand);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetListBasket([FromQuery] PageRequest pageRequest)
        {
            GetListBasketQuery getListBasketQuery = new() { PageRequest = pageRequest };
            GetListResponse<BasketListDto> result = await Mediator.Send(getListBasketQuery);
            return Ok(result);
        }
        [HttpGet]
        // [Route("{productId}")]
        public async Task<IActionResult> GetByProductIdBasket([FromQuery] PageRequest pageRequest, [FromQuery] int productId)
        {
            GetByProductIdBasketQuery getListBasketQuery = new() { PageRequest = pageRequest, ProductId = productId };
            GetListResponse<BasketListDto> result = await Mediator.Send(getListBasketQuery);
            return Ok(result);
        }
    }
}
