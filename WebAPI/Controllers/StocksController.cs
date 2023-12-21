using Application.Features.Stocks.Command.CreateStock;
using Application.Features.Stocks.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StocksController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateStockCommand createStockCommand)
        {
            CreateStockDto result = await Mediator.Send(createStockCommand);
            return Ok(result);
        }
    }
}
