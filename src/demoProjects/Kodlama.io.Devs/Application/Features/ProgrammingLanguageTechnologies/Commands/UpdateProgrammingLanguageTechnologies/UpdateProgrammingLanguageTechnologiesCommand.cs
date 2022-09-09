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

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnologies
{
    public class UpdateProgrammingLanguageTechnologiesCommand : IRequest<UpdatedProgrammingLanguageTechnologiesDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageid { get; set; }
        public int ProgrammingLanguageTechnologiesName { get; set; }
        public class UpdateProgrammingLanguageTechnologiesCommandHandler : IRequestHandler<UpdateProgrammingLanguageTechnologiesCommand, UpdatedProgrammingLanguageTechnologiesDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;

            public UpdateProgrammingLanguageTechnologiesCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedProgrammingLanguageTechnologiesDto> Handle(UpdateProgrammingLanguageTechnologiesCommand request, CancellationToken cancellationToken)
            {
                var mapUpdateProgrammingLanguageTechnology = _mapper.Map<ProgrammingLanguageTechnology>(request);
                var updatedResult = await _programmingLanguageTechnologyRepository.UpdateAsync(mapUpdateProgrammingLanguageTechnology);
                var result = _mapper.Map<UpdatedProgrammingLanguageTechnologiesDto>(updatedResult);
                return result;
            }
        }
    }
}
