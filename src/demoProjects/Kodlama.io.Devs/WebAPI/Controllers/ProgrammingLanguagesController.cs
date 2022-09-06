using Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Dtos;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Application.Features.ProgrammingLanguage.Queries.GetListProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Queries.GetByProgrammingLanguageId;
using Application.Features.ProgrammingLanguage.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Commands.DeleteProgrammingLanguage;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreateProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);
            return Created("", result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var result = await Mediator.Send(new GetListProgrammingLanguageQuery { PageRequest = pageRequest });
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByProgrammingLanguageIdQuery getByProgrammingLanguageIdQuery)
        {
            GetByProgrammingLanguageIdDto result = await Mediator.Send(getByProgrammingLanguageIdQuery);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdateProgrammingLanguageDto result = await Mediator.Send(updateProgrammingLanguageCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeleteProgrammingLanguageDto result = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Ok(result);
        }
    }
}
