using Application.Features.Products.Command;
using Application.Features.Products.Dtos;
using Application.Features.Products.Queries.GetAll;
using Application.Features.Products.Queries.GetAllDynamic;
using Application.Features.Products.Queries.GetByCategoryId;
using Application.Features.Products.Queries.GetById;
using Application.Services.ProductService;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Ürün ekleme işlemi yapıyor!!!
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommand createProductCommand)
        {
            CreateProductDto createProductDto = await Mediator.Send(createProductCommand);
            return Created("", createProductDto);
        }
        /// <summary>
        /// Ürün Id'ye göre silme işlemi yapıyor!!!
        /// </summary>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCommand deleteProductCommand)
        {
            DeleteProductDto deleteProductDto = await Mediator.Send(deleteProductCommand);
            return Ok(deleteProductDto);
        }
        /// <summary>
        /// Ürün Güncelleme işlemi yapıyor!!!
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProductCommand)
        {
            UpdateProductDto updateProductDto = await Mediator.Send(updateProductCommand);
            return Ok(updateProductDto);
        }
        /// <summary>
        /// Ürün Id'ye göre getirme işlemi yapıyor!!!
        /// </summary>
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductQuery getByIdProductQuery)
        {
            GetByIdProductDto getByIdProductDto = await Mediator.Send(getByIdProductQuery);
            return Ok(getByIdProductDto);
        }
        /// <summary>
        /// Ürün Listeleme işlemi yapıyor!!!
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetAllProductQuery getAllProductQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetAllProductDto> getListResponse = await Mediator.Send(getAllProductQuery);
            return Ok(getListResponse);
        }
        /// <summary>
        /// Ürün Dynamic Listeleme işlemi yapıyor!!!
        /// </summary>
        [HttpPost("/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest,
                                                   [FromBody] Dynamic? dynamic = null)
        {
            GetAllProductByDynamicQuery getAllProductByDynamicQuery = new() { Dynamic = dynamic, PageRequest = pageRequest };
            GetListResponse<GetAllProductDto> result = await Mediator.Send(getAllProductByDynamicQuery);
            return Ok(result);
        }
        [HttpGet]
        [Route("{categoryId}")]
        public async Task<IActionResult> GetByCategoryId([FromRoute] int categoryId, [FromQuery] PageRequest pageRequest)
        {
            GetByCategoryIdQuery getByCategoryIdQuery = new() { CategoryId = categoryId, PageRequest = pageRequest };
            GetListResponse<GetByCategoryIdDto> result = await Mediator.Send(getByCategoryIdQuery);
            return Ok(result);
        }
        [HttpGet("qrcode/{productId}")]
        public async Task<IActionResult> GetQrCodeToProduct([FromRoute] int productId)
        {
            var data = await _productService.QrCodeToProductAsync(productId);
            return File(data, "image/png");
        } 
    }
}
