using Application.Features.Favorites.Command.CreateFavorite;
using Application.Features.Favorites.Command.DeleteFavorite;
using Application.Features.Favorites.Command.UpdateFavorite;
using Application.Features.Favorites.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateFavoriteCommand createFavoriteCommand)
        {
            CreateFavoriteDto createFavoriteDto = await Mediator.Send(createFavoriteCommand);
            return Created("", createFavoriteDto);
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteFavoriteCommand deleteFavoriteCommand)
        {
            DeleteFavoriteDto result = await Mediator.Send(deleteFavoriteCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateFavoriteCommand updateFavoriteCommand)
        {
            UpdateFavoriteDto result = await Mediator.Send(updateFavoriteCommand);
            return Ok(result);
        }
    }
}
