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

namespace Application.Features.ProgrammingLanguages.Queries.GetByProgrammingLanguageId
{
    public class GetByProgrammingLanguageIdQuery:IRequest<GetByProgrammingLanguageIdDto>
    {
        public int Id { get; set; }
        public class GetByProgrammingLanguageIdQueryHandler : IRequestHandler<GetByProgrammingLanguageIdQuery, GetByProgrammingLanguageIdDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguagesRules _programmingLanguageRules;

            public GetByProgrammingLanguageIdQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguagesRules programmingLanguageRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageRules = programmingLanguageRules;
            }

            public async Task<GetByProgrammingLanguageIdDto> Handle(GetByProgrammingLanguageIdQuery request, CancellationToken cancellationToken)
            {
                var getId = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id);

                _programmingLanguageRules.ProgrammingLanguageShouldExistsWhenRequested(getId);

                var mappedGetByProgrammingLanguageIdDto = _mapper.Map<GetByProgrammingLanguageIdDto>(getId);
                return mappedGetByProgrammingLanguageIdDto;
            }
        }
    }
}
