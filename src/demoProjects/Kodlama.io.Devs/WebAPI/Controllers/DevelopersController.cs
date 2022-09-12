using Application.Features.Developers.Command.LoginDeveloper;
using Application.Features.Developers.Command.RegisterDeveloper;
using Application.Features.Developers.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDeveloperCommand registerDeveloperCommand)
        {
            TokenDto result = await Mediator.Send(registerDeveloperCommand);
            return Created("", result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDeveloperCommand loginDeveloperCommand)
        {
            TokenDto result = await Mediator.Send(loginDeveloperCommand);
            return Created("", result);
        }

    }
}
