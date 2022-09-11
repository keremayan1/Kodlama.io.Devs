using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand:IRequest<CreateProgrammingLanguageDto>
    {
        public string Name { get; set; }
        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreateProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageRules;
            public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageRules = programmingLanguageRules;
            }

            public async Task<CreateProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageRules.ProgrammingLanguageNameCantDuplicatedWhenInserted(request.Name);
                var mappedProgrammingLanguages = _mapper.Map<Domain.Entities.ProgrammingLanguage>(request);
                var addResult = await _programmingLanguageRepository.AddAsync(mappedProgrammingLanguages);
                var result = _mapper.Map<CreateProgrammingLanguageDto>(addResult);
                return result;
            }
        }
    }
}
