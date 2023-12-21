using Application.Features.Invoices.Command.CreateInvoice;
using Application.Features.Invoices.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoicesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateInvoiceCommand createInvoiceCommand)
        {
            CreateInvoiceDto result = await Mediator.Send(createInvoiceCommand);
            return Ok(result);
        }
    }
}
