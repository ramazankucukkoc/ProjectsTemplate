using Application.Features.Categories.Command;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Queries.GetAll;
using Application.Features.Categories.Queries.GetById;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        /// <summary>
        /// Kategorilerdeki Ekleme işlemi yapıyor!!!
        /// </summary>
        [HttpPost]

        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategeoryCommand)
        {
            CreateCategoryDto createCategoryDto = await Mediator.Send(createCategeoryCommand);
            return Created("", createCategoryDto);
        }
        /// <summary>
        /// Kategorilerdeki Id'ye silme işlemi yapıyor!!!
        /// </summary>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCategoryCommand deleteCategoryCommand)
        {
            DeleteCategoryDto deleteCategoryDto = await Mediator.Send(deleteCategoryCommand);
            return Ok(deleteCategoryDto);
        }
        /// <summary>
        /// Kategorilerdeki Güncelleme işlemi yapıyor!!!
        /// </summary>
        /// <param name="UpdateCategoryCommand">Kategorilerdeki Güncelleme işlemi yapıyor!!!</param>
        /// <returns>UpdateCategoryDto</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            UpdateCategoryDto updateCategoryDto = await Mediator.Send(updateCategoryCommand);
            return Ok(updateCategoryDto);
        }
        /// <summary>
        /// Kategorilerdeki Id'ye göre getirme işlemi yapıyor!!!
        /// </summary>
        /// <param name="GetByIdCategoryQuery">Kategorilerdeki Id'ye göre getirme işlemi yapıyor!!!</param>
        /// <returns>GetByIdCategoryDto</returns>
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCategoryQuery getByIdCategoryQuery)
        {
            GetByIdCategoryDto getByIdCategoryDto = await Mediator.Send(getByIdCategoryQuery);
            return Ok(getByIdCategoryDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetAllCategoryQuery getAllCategoryQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetAllCategoryDto> result = await Mediator.Send(getAllCategoryQuery);
            return Ok(result);
        }

    }
}
