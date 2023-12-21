using Application.Features.Personels.Command.CreatePersonel;
using Application.Features.Personels.Command.DeletePersonel;
using Application.Features.Personels.Command.UpdatePersonel;
using Application.Features.Personels.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonelsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatePersonelCommand createPersonelCommand)
        {
            CreatePersonelDto result = await Mediator.Send(createPersonelCommand);
            return Ok(result);
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeletePersonelCommand deletePersonelCommand)
        {
            DeletePersonelDto result = await Mediator.Send(deletePersonelCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePersonelCommand updatePersonelCommand)
        {
            UpdatePersonelDto result = await Mediator.Send(updatePersonelCommand);
            return Ok(result);
        }

    }
}
