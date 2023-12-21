using Application.Features.Auths.Command.DisableEmailAuthenticator;
using Application.Features.Auths.Command.DisableOtpAuthenticator;
using Application.Features.Auths.Command.EnableEmailAuthenticator;
using Application.Features.Auths.Command.EnableOtpAuthenticator;
using Application.Features.Auths.Command.Login;
using Application.Features.Auths.Command.LoginWithGoogle;
using Application.Features.Auths.Command.LoginWithMicrosoft;
using Application.Features.Auths.Command.RefleshToken;
using Application.Features.Auths.Command.Register;
using Application.Features.Auths.Command.RevokeToken;
using Application.Features.Auths.Command.VerifyEmailAuthenticator;
using Application.Features.Auths.Command.VerifyOtpAuthenticator;
using Application.Features.Auths.Dtos;
using Core.Application.DTOs;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/auth/[action]")]
    [ApiController]
    public class AuthsController : BaseController
    {
        //WebAPIConfiguration bu bize ileride lazım olacaktır.
        private readonly WebAPIConfiguration _configuration;
        public AuthsController(IConfiguration configuration)
        {
            _configuration = configuration.GetSection("WebAPIConfiguration").Get<WebAPIConfiguration>();
        }
        /// <summary>
        /// Kullanıcı Kaydetme işlemi yapıyor!!!
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new() { UserForRegisterDto = userForRegisterDto, IpAddress = getIpAddress() };
            RegisteredDto registeredDto = await Mediator.Send(registerCommand);
            setRefreshTokenCookie(registeredDto.RefreshToken);
            return Ok(registeredDto.AccessToken);
        }
        /// <summary>
        /// Kullanıcı Giriş işlemi yapıyor!!!
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new() { UserForLoginDto = userForLoginDto, IpAddress = getIpAddress() };
            LoggedDto result = await Mediator.Send(loginCommand);

            if (result.RefreshToken is not null) setRefreshTokenCookie(result.RefreshToken);

            return Ok(result.AccessToken);
        }
        /// <summary>
        /// Kullanıcı Google ile giriş işlemi yapıyor!!!
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> LoginWithGoogle([FromBody] LoginWithGoogleDto loginWithGoogleDto)
        {
            LoginWithGoogleCommand loginWithGoogleCommand = new()
            { LoginWithGoogleDto = loginWithGoogleDto, IpAddrres = getIpAddress() };

            LoggedDto result = await Mediator.Send(loginWithGoogleCommand);

            if (result.RefreshToken is not null) setRefreshTokenCookie(result.RefreshToken);

            return Ok(result.AccessToken);
        }
        [HttpPost]
        public async Task<IActionResult> LoginWithMicrosoft([FromBody] String microsoftAccessToken)
        {
            LoginWithMicrosoftCommand loginWithMicrosoftCommand = new() { IpAddress = getIpAddress(), MicrosoftAccessToken = microsoftAccessToken };
            LoggedDto result = await Mediator.Send(loginWithMicrosoftCommand);
            if (result.RefreshToken is not null) setRefreshTokenCookie(result.RefreshToken);

            return Ok(result.AccessToken);
        }

        /// <summary>
        /// Kullanıcı e-mailini dogrulanmsını etkinleştir. !!!
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> EnableEmailAuthenticator()
        {
            EnableEmailAuthenticatorCommand enableEmailAuthenticatorCommand = new()
            {
                UserId = getUserIdFromRequest(),
                VerifyEmailUrlPrefix = $"{_configuration.APIDomain}/Auths/EnableEmailAuthenticator"
            };
            EnabledEmailAuthenticatorDto result= await Mediator.Send(enableEmailAuthenticatorCommand);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> EnableOtpAuthenticator()
        {
            EnableOtpAuthenticatorCommand enableOtpAuthenticatorCommand = new() { UserId = getUserIdFromRequest() };
            await Mediator.Send(enableOtpAuthenticatorCommand);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> VerifyEmailAuthenticator([FromQuery] VerifyEmailAuthenticatorCommand verifyEmailAuthenticatorCommand)
        {
            await Mediator.Send(verifyEmailAuthenticatorCommand);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> VerifyOtpAuthenticator([FromBody] VerifyOtpAuthenticatorDto verifyOtpAuthenticatorDto)
        {
            VerifyOtpAuthenticatorCommand verifyOtpAuthenticatorCommand = new()
            {
                ActivationCode = verifyOtpAuthenticatorDto.authenticatorCode,
                UserId = getUserIdFromRequest()
            };
            await Mediator.Send(verifyOtpAuthenticatorCommand);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> RefreshToken()
        {
            RefreshTokenCommand refreshTokenCommand = new()
            {
                RefleshToken = getRefreshTokenFromCookies(),
                IpAddress = getIpAddress()
            };
            RefreshedTokensDto result = await Mediator.Send(refreshTokenCommand);
            setRefreshTokenCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }
        [HttpPut]
        public async Task<IActionResult> RevokeToken([FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] RevokeTokenServiceDto? revokeTokenServiceDto)
        {
            RevokeTokenCommand revokeTokenCommand = new()
            { Token = revokeTokenServiceDto.RefreshToken ?? getRefreshTokenFromCookies(), IpAddress = getIpAddress() };
            RevokedTokenDto result = await Mediator.Send(revokeTokenCommand);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> DisableEmailAuthenticator()
        {
            DisableEmailAuthenticatorCommand disableEmailAuthenticatorCommand = new() { UserId = getUserIdFromRequest() };
            await Mediator.Send(disableEmailAuthenticatorCommand);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> DisableOtpAuthenticator()
        {
            DisableOtpAuthenticatorCommand disableOtpAuthenticatorCommand = new() { UserId = getUserIdFromRequest() };
            await Mediator.Send(disableOtpAuthenticatorCommand);
            return Ok();
        }


        private void setRefreshTokenCookie(RefreshToken refreshToken)
        {
            CookieOptions options = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, options);
        }
        private string? getRefreshTokenFromCookies() { return Request.Cookies["refreshToken"]; }

    }
}
