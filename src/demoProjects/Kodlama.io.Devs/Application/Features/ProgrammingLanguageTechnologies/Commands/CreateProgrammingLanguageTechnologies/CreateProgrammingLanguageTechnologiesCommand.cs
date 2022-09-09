using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnologies
{
    public class CreateProgrammingLanguageTechnologiesCommand:IRequest<CreatedProgrammingLanguageTechnologiesDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string ProgrammingLanguageTechnologyName { get; set; }
        public class CreateProgrammingLanguageTechnologiesCommandHandler : IRequestHandler<CreateProgrammingLanguageTechnologiesCommand, CreatedProgrammingLanguageTechnologiesDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;

            public CreateProgrammingLanguageTechnologiesCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<CreatedProgrammingLanguageTechnologiesDto> Handle(CreateProgrammingLanguageTechnologiesCommand request, CancellationToken cancellationToken)
            {
                var mapProgrammingLanguageTechnology = _mapper.Map<ProgrammingLanguageTechnology>(request);
                
                var addResult = await _programmingLanguageTechnologyRepository.AddAsync(mapProgrammingLanguageTechnology);
                
                var result = _mapper.Map<CreatedProgrammingLanguageTechnologiesDto>(addResult);
                
                return result;
            }
        }
    }
}
