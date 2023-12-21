using Application.Features.Cities.Command.CreateCities;
using Application.Features.Cities.Command.DeleteCities;
using Application.Features.Cities.Command.UpdateCities;
using Application.Features.Cities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CitiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCitiesCommand createCitiesCommand)
        {
            CreateCityDto result = await Mediator.Send(createCitiesCommand);
            return Ok(result);
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCitiesCommand deleteCitiesCommand)
        {
            DeleteCityDto result = await Mediator.Send(deleteCitiesCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCitiesCommand updateCitiesCommand)
        {
            UpdateCityDto result = await Mediator.Send(updateCitiesCommand);
            return Ok(result);
        }
    }
}
