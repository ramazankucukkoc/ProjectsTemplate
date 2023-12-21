using Application.Features.Orders.Command;
using Application.Features.Orders.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        /// <summary>
        /// Sipariş Ekleme yapıyor!!!
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOrderCommand createOrderCommand)
        {
            CreateOrderDto createOrderDto = await Mediator.Send(createOrderCommand);
            return Ok(createOrderDto);
        }
    }
}
