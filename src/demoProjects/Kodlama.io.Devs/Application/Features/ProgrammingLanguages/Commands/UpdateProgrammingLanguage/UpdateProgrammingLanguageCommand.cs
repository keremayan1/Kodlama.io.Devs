using Application.Features.ProgrammingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand:IRequest<UpdateProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdateProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<UpdateProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                var mappedProgrammingLanguages = _mapper.Map<ProgrammingLanguage>(request);
                var updatedProgrammingLanguages = await _programmingLanguageRepository.UpdateAsync(mappedProgrammingLanguages);
                var result = _mapper.Map<UpdateProgrammingLanguageDto>(updatedProgrammingLanguages);
                return result;
            }
        }
    }
}
