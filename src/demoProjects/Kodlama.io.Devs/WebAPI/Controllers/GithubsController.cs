using Application.Features.Githubs.Commands.CreateGithub;
using Application.Features.Githubs.Commands.DeleteGithub;
using Application.Features.Githubs.Commands.UpdateGithub;
using Application.Features.Githubs.Dtos;
using Application.Features.Githubs.Models;
using Application.Features.Githubs.Queries.GetByGithubId;
using Application.Features.Githubs.Queries.GetListGithub;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGithubCommand createGithubCommand)
        {
            CreatedGithubDto result = await Mediator.Send(createGithubCommand);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGithubCommand updateGithubCommand)
        {
            UpdatedGithubDto result = await Mediator.Send(updateGithubCommand);
            return Created("", result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteGithubCommand deleteGithubCommand)
        {
            DeletedGithubDto result = await Mediator.Send(deleteGithubCommand);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GithubListModel result = await Mediator.Send(new GetListGithubQuery { PageRequest=pageRequest});
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByGithubIdQuery getByGithubIdQuery)
        {
            GetByGithubIdDto result = await Mediator.Send(getByGithubIdQuery);
            return Ok(result);
        }
    }
}
