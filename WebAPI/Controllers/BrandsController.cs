using Application.Features.Brands.Command.CreateBrand;
using Application.Features.Brands.Command.DeleteBrand;
using Application.Features.Brands.Command.UpdateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Queries.GetByIdBrand;
using Application.Features.Brands.Queries.GetListBrand;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBrandQuery getByIdBrandQuery)
        {
            BrandDto brandDto = await Mediator.Send(getByIdBrandQuery);
            return Ok(brandDto);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
            GetListResponse<BrandListDto> getList = await Mediator.Send(getListBrandQuery);
            return Ok(getList);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
        {
            CreateBrandDto createBrandDto = await Mediator.Send(createBrandCommand);
            return Created("", createBrandDto);
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBrandCommand deleteBrandCommand)
        {
            DeleteBrandDto deleteBrandDto = await Mediator.Send(deleteBrandCommand);
            return Ok(deleteBrandDto);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
        {
            UpdateBrandDto updateBrandDto = await Mediator.Send(updateBrandCommand);
            return Ok(updateBrandDto);
        }
        /// <summary>
        /// Markalardaki Çoklu Ekleme(AddRange) işlemi yapıyor!!!
        /// </summary>
        [HttpPost("BulkInsert")]
        public async Task<IActionResult> BulkInsert([FromBody] CreateBulkBrandCommand createBulkBrandCommand)
        {
            List<CreateBrandDto> result = await Mediator.Send(createBulkBrandCommand);
            return Ok(result);
        }
    }
}
