using Application.Features.OperationClaims.Commands.CreateOperationClaims;
using Application.Features.OperationClaims.Commands.DeleteOperationClaims;
using Application.Features.OperationClaims.Commands.UpdateOperationClaims;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using Application.Features.OperationClaims.Queries.GetListOperationClaims;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimsCommand createOperationClaimsCommand)
        {
            CreatedOperationClaimsDto result = await Mediator.Send(createOperationClaimsCommand);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimsCommand updateOperationClaimsCommand)
        {
            UpdatedOperationClaimsDto result = await Mediator.Send(updateOperationClaimsCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteOperationClaimsCommand deleteOperationClaimsCommand)
        {
            DeletedOperationClaimsDto result = await Mediator.Send(deleteOperationClaimsCommand);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var result = await Mediator.Send(new GetListOperationClaimsQuery { PageRequest = pageRequest });
            return Ok(result);
        }
    }
}
