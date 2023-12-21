using Application.Features.Users.Commands;
using Application.Features.Users.Dtos;
using Application.Features.Users.Queries.GetByIdUserQuery;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserCommnad deleteUserCommnad)
        {
            DeletedUserDto deletedUserDto = await Mediator.Send(deleteUserCommnad);
            return Ok(deletedUserDto);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
        {
            UpdateUserDto deletedUserDto = await Mediator.Send(updateUserCommand);
            return Ok(deletedUserDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFromAuth([FromBody] UpdateUserFromAuthCommand updateUserFromAuthCommand)
        {
            updateUserFromAuthCommand.Id = getUserIdFromRequest();
            UpdatedUserFromAuthDto result = await Mediator.Send(updateUserFromAuthCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            ChangePasswordCommand changePasswordCommand = new() { UserId = getUserIdFromRequest(), CurrentPassword = changePasswordDto.CurrentPassword, NewPassword = changePasswordDto.NewPassword };

            string islem = await Mediator.Send(changePasswordCommand);
            return Ok(islem);
        }

        [HttpPut]

        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand forgotPasswordCommand)
        {
            var result = await Mediator.Send(forgotPasswordCommand);
            return Ok(result);
        }


        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetByIdUser([FromRoute] GetByIdUserQuery getByIdUserQuery)
        {
            GetByIdUserDto getByIdUserDto = await Mediator.Send(getByIdUserQuery);
            return Ok(getByIdUserDto);
        }
    }
}
