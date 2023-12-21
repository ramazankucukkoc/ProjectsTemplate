using Application.Features.IndividualCustomers.Command.CreateIndividualCustomer;
using Application.Features.IndividualCustomers.Command.DeleteIndividualCustomer;
using Application.Features.IndividualCustomers.Command.UpdateIndividualCustomer;
using Application.Features.IndividualCustomers.Dtos;
using Application.Features.IndividualCustomers.Queries.GetByCustomerIdIndividualCustomer;
using Application.Features.IndividualCustomers.Queries.GetByIdIndividualCustomer;
using Application.Features.IndividualCustomers.Queries.GetListIndividualCustomers;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IndividualCustomersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateIndividualCustomerCommand createIndividualCustomerCommand)
        {
            CreateIndividualCustomerDto result = await Mediator.Send(createIndividualCustomerCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] DeleteIndividualCustomerCommand deleteIndividualCustomerCommand)
        {
            DeleteIndividualCustomerDto result = await Mediator.Send(deleteIndividualCustomerCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateIndividualCustomerCommand updateIndividualCustomerCommand)
        {
            UpdateIndividualCustomerDto result = await Mediator.Send(updateIndividualCustomerCommand);
            return Ok(result);
        }
        [HttpGet]
        [Route("{CustomerId}")]
        public async Task<IActionResult> GetByCustomerId([FromRoute] GetByCustomerIdIndividualCustomerQuery getByCustomerIdIndividualCustomerQuery)
        {
            IndividualCustomerDto result = await Mediator.Send(getByCustomerIdIndividualCustomerQuery);
            return Ok(result);
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdIndividualCustomerQuery getByIdIndividualCustomerQuery)
        {
            IndividualCustomerDto result = await Mediator.Send(getByIdIndividualCustomerQuery);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListIndividualCustomerQuery getListIndividualCustomerQuery = new() { PageRequest = pageRequest };
            GetListResponse<IndividualCustomerDto> result = await Mediator.Send(getListIndividualCustomerQuery);
            return Ok(result);
        }
    }
}
