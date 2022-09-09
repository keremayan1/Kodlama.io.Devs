using Application.Features.ProgrammingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand:IRequest<DeleteProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeleteProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<DeleteProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                var getId = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id);
                var deleteProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(getId);
                var result = _mapper.Map<DeleteProgrammingLanguageDto>(deleteProgrammingLanguage);
                return result;
            }
        }
    }
}
