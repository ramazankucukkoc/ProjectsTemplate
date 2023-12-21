using Application.Features.ProductBranchs.Command.CreateProductBranch;
using Application.Features.ProductBranchs.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductBranchesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductBranchCommand createProductBranchCommand)
        {
            CreateProductBranchDto result = await Mediator.Send(createProductBranchCommand);
            return Ok(result);
        }

    }
}
