using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnologies
{
    public class DeleteProgrammingLanguageTechnologiesCommand : IRequest<DeletedProgrammingLanguageTechnologiesDto>
    {
        public int Id { get; set; }
        public class DeleteProgrammingLanguageTechnologiesCommandHandler : IRequestHandler<DeleteProgrammingLanguageTechnologiesCommand, DeletedProgrammingLanguageTechnologiesDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;
            public DeleteProgrammingLanguageTechnologiesCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<DeletedProgrammingLanguageTechnologiesDto> Handle(DeleteProgrammingLanguageTechnologiesCommand request, CancellationToken cancellationToken)
            {
                var getId = await _programmingLanguageTechnologyRepository.GetAsync(p => p.Id == request.Id);
                var deletedProgrammingLanguageTechnology = await _programmingLanguageTechnologyRepository.DeleteAsync(getId);
                var result = _mapper.Map<DeletedProgrammingLanguageTechnologiesDto>(deletedProgrammingLanguageTechnology);
                return result;
            }
        }
    }
}
