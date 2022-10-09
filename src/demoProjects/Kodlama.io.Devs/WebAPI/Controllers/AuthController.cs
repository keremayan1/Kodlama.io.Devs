using Application.Features.Auths.Commands.Register;
using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            var registeredCommand = new RegisterCommand { UserForRegisterDto = userForRegisterDto, IpAddress = GetIpAddress() };
            RegisteredDto result = await Mediator.Send(registeredCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);

            
        }
        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new()
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(7)
            };
            Response.Cookies.Append("refreshtoken", refreshToken.Token, cookieOptions);
        }
    }
}
