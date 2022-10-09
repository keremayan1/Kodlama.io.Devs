using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaims;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim;
using Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            CreatedUserOperationClaimDto result = await Mediator.Send(createUserOperationClaimCommand);
            return Created("", result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            UserOperationClaimModel result = await Mediator.Send(new GetListUserOperationClaimQuery { PageRequest = pageRequest });
            return Ok(result);
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById([FromQuery]PageRequest pageRequest, [FromRoute] int userId)
        {
            UserOperationClaimModel result = await Mediator.Send(new GetByIdUserOperationClaimQuery { PageRequest = pageRequest,UserId=userId});
            return Ok(result);
        }
    }
}
