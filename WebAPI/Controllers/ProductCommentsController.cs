using Application.Features.ProductComments.Command.CreateProductComment;
using Application.Features.ProductComments.Command.DeleteProductComment;
using Application.Features.ProductComments.Command.UpdateProductComment;
using Application.Features.ProductComments.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductCommentsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommentCommand createProductCommentCommand)
        {
            CreateProductCommentDto result = await Mediator.Send(createProductCommentCommand);
            return Ok(result);
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCommentCommand deleteProductCommentCommand)
        {
            DeleteProductCommentDto result = await Mediator.Send(deleteProductCommentCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommentCommand updateProductCommentCommand)
        {
            UpdateProductCommentDto result = await Mediator.Send(updateProductCommentCommand);
            return Ok(result);
        }


    }
}
