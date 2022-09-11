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
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RegisterDeveloperCommand registerDeveloperCommand)
        {
            TokenDto tokenDto = await Mediator.Send(registerDeveloperCommand);
            return Created("", tokenDto);
        }

    }
}
