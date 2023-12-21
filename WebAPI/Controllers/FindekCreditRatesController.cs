using Application.Features.FindeksCreditRates.Command.CreateFindeksCreditRate;
using Application.Features.FindeksCreditRates.Command.DeleteFindeksCreditRate;
using Application.Features.FindeksCreditRates.Command.UpdateByUserIdFindeksCreditRateFromService;
using Application.Features.FindeksCreditRates.Command.UpdateFindeksCreditRate;
using Application.Features.FindeksCreditRates.Command.UpdateFindeksCreditRateFromService;
using Application.Features.FindeksCreditRates.Dtos;
using Application.Features.FindeksCreditRates.Queries.GetByCustomerIdFindeksCreditRate;
using Application.Features.FindeksCreditRates.Queries.GetByIdFindeksCreditRate;
using Application.Features.FindeksCreditRates.Queries.GetListFindeksCreditRate;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindekCreditRatesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateFindeksCreditRateCommand createFindeksCreditRateCommand)
        {
            CreateFindeksCreditRateDto result = await Mediator.Send(createFindeksCreditRateCommand);
            return Ok(result);
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteFindeksCreditRateCommand deleteFindeksCreditRateCommand)
        {
            DeleteFindeksCreditRateDto result = await Mediator.Send(deleteFindeksCreditRateCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFindeksCreditRateCommand updateFindeksCreditRateCommand)
        {
            UpdateFindeksCreditRateDto result = await Mediator.Send(updateFindeksCreditRateCommand);
            return Ok(result);
        }
        [HttpPut("ByAuth/FromService")]
        //[Route("/ByAuth/FromService")]

        public async Task<IActionResult> UpdateByAuthFromService([FromBody] UpdateByAuthFromServiceRequestDto updateByAuthFromServiceRequestDto)
        {
            UpdateByUserIdFindeksCreditRateFromServiceCommand updateByUserIdFindeksCreditRateFromServiceCommand =
                new()
                {
                    UserId = getUserIdFromRequest(),
                    IdentityNumber = updateByAuthFromServiceRequestDto.IdentityNumber
                };

            UpdateFindeksCreditRateDto result = await Mediator.Send(updateByUserIdFindeksCreditRateFromServiceCommand);
            return Ok(result);
        }
        [HttpPut("FromService")]

        public async Task<IActionResult> UpdateFromService([FromBody] UpdateFindeksCreditRateFromServiceCommand updateFindeksCreditRateFromServiceCommand)
        {
            UpdateFindeksCreditRateDto result = await Mediator.Send(updateFindeksCreditRateFromServiceCommand);
            return Ok(result);
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdFindeksCreditRateQuery getByIdFindeksCreditRateQuery)
        {
            FindeksCreditRateDto result = await Mediator.Send(getByIdFindeksCreditRateQuery);
            return Ok(result);
        }
        [HttpGet]
        [Route("{CustomerId}")]
        public async Task<IActionResult> GetByCustomerId([FromRoute] GetByCustomerIdFindeksCreditRateQuery getByCustomerIdFindeksCreditRateQuery)
        {
            FindeksCreditRateDto result = await Mediator.Send(getByCustomerIdFindeksCreditRateQuery);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListFindeksCreditRateQuery getListFindeksCreditRateQuery = new() { PageRequest = pageRequest };

            GetListResponse<FindeksCreditRateDto> result = await Mediator.Send(getListFindeksCreditRateQuery);
            return Ok(result);
        }
    }
}
