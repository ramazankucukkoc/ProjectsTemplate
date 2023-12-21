using Application.Features.Sales.Command.CreateSale;
using Application.Features.Sales.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSaleCommand createSaleCommand)
        {
            CreateSaleDto createSaleDto = await Mediator.Send(createSaleCommand);
            return Ok(createSaleDto);
        }
    }
}
