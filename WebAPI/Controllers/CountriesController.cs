using Application.Features.Countries.Command.CreateCountry;
using Application.Features.Countries.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountriesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCountryCommand createCountryCommand)
        {
            CreateCountryDto result = await Mediator.Send(createCountryCommand);
            return Ok(result);
        }


    }
}
