using Application.Features.CorporateCustomers.Command.CreateCorporateCustomer;
using Application.Features.CorporateCustomers.Command.DeleteCorporateCustomer;
using Application.Features.CorporateCustomers.Command.UpdateCorporateCustomer;
using Application.Features.CorporateCustomers.Dtos;
using Application.Features.CorporateCustomers.Queries.GetByCustomerIdCorporateCustomer;
using Application.Features.CorporateCustomers.Queries.GetByIdCorporateCustomer;
using Application.Features.CorporateCustomers.Queries.GetListCorporateCustomer;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CorporateCustomersController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCorporateCustomerCommand createCorporateCustomerCommand)
        {
            CreateCorporateCustomerDto result = await Mediator.Send(createCorporateCustomerCommand);
            return Ok(result);
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCorporateCustomerCommand deleteCorporateCustomerCommand)
        {
            DeleteCorporateCustomerDto result = await Mediator.Send(deleteCorporateCustomerCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCorporateCustomerCommand updateCorporateCustomerCommand)
        {
            UpdateCorporateDto result = await Mediator.Send(updateCorporateCustomerCommand);
            return Ok(result);
        }
        [HttpGet]
        [Route("{CustomerId}")]
        public async Task<IActionResult> GetByCustomerId([FromRoute] GetByCustomerIdCorporateCustomerQuery getByCustomerIdCorporateCustomerQuery)
        {
            CorporateCustomerDto result = await Mediator.Send(getByCustomerIdCorporateCustomerQuery);
            return Ok(result);
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCorporateCustomerQuery getByIdCorporateCustomerQuery)
        {
            CorporateCustomerDto result = await Mediator.Send(getByIdCorporateCustomerQuery);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCorporateCustomerQuery getListCorporateCustomerQuery = new() { PageRequest = pageRequest };
            GetListResponse<CorporateCustomerDto> result = await Mediator.Send(getListCorporateCustomerQuery);
            return Ok(result);
        }

    }
}
