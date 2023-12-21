using Application.Features.Departmans.Command.CreateDepartman;
using Application.Features.Departmans.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmansController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDepartmanCommand createDepartmanCommand)
        {
            List<CreateDepartmanDto> results = await Mediator.Send(createDepartmanCommand);
            return Ok(results);
        }
    }
}
