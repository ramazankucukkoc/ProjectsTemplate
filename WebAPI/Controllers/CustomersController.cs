using Application.Features.Customers.Command.CreateCustomer;
using Application.Features.Customers.Command.DeleteCustomer;
using Application.Features.Customers.Command.UpdateCustomer;
using Application.Features.Customers.Dtos;
using Application.Features.Customers.Queries.GetByIdCustomer;
using Application.Features.Customers.Queries.GetByUserIdCustomer;
using Application.Features.Customers.Queries.GetListCustomer;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            CustomerDto result = await Mediator.Send(createCustomerCommand);
            return Ok(result);
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerCommand deleteCustomerCommand)
        {
            CustomerDto result = await Mediator.Send(deleteCustomerCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            CustomerDto customerDto = await Mediator.Send(updateCustomerCommand);
            return Ok(customerDto);
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerQuery getByIdCustomerQuery)
        {
            CustomerDto result = await Mediator.Send(getByIdCustomerQuery);
            return Ok(result);
        }
        [HttpGet]
        [Route("{UserId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] GetByUserIdCustomerQuery getByUserIdCustomerQuery)
        {
            CustomerDto result = await Mediator.Send(getByUserIdCustomerQuery);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetListCustomer([FromQuery] PageRequest pageRequest)
        {
            GetListCustomerQuery getListCustomerQuery = new() { PageRequest = pageRequest };
            GetListResponse<CustomerDto> result = await Mediator.Send(getListCustomerQuery);
            return Ok(result);
        }



    }
}
