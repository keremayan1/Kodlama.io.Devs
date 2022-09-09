using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnologies;
using Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnologies;
using Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnologies;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnologies;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageTechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageTechnologiesCommand createProgrammingLanguageTechnologiesCommand)
        {
            CreatedProgrammingLanguageTechnologiesDto result = await Mediator.Send(createProgrammingLanguageTechnologiesCommand);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageTechnologiesCommand updateProgrammingLanguageTechnologiesCommand)
        {
            UpdatedProgrammingLanguageTechnologiesDto result = await Mediator.Send(updateProgrammingLanguageTechnologiesCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteProgrammingLanguageTechnologiesCommand deleteProgrammingLanguageTechnologiesCommand)
        {
            DeletedProgrammingLanguageTechnologiesDto result = await Mediator.Send(deleteProgrammingLanguageTechnologiesCommand);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]PageRequest pageRequest)
        {
            ProgrammingLanguageTechnologiesListModel result = await Mediator.Send(new GetListProgrammingLanguageTechnologiesQuery { PageRequest = pageRequest });
            return Ok(result);
        }
    }
}
