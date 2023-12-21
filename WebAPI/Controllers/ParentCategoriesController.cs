using Application.Features.ParentCategories.Command;
using Application.Features.ParentCategories.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ParentCategoriesController : BaseController
    {
        /// <summary>
        /// Alt Kategori ekleme işlemi yapıyor!!!
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateParentCategoryCommand createParentCategoryCommand)
        {
            CreateParentCategoryDto createParentCategoryDto = await Mediator.Send(createParentCategoryCommand);
            return Ok(createParentCategoryDto);
        }

    }
}
