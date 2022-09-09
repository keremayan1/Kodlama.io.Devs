using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnologies
{
    public class GetListProgrammingLanguageTechnologiesQuery:IRequest<ProgrammingLanguageTechnologiesListModel>
    {
        public PageRequest   PageRequest { get; set; }
        public class GetListProgrammingLanguageTechnologiesQueryHandler : IRequestHandler<GetListProgrammingLanguageTechnologiesQuery, ProgrammingLanguageTechnologiesListModel>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingLanguageTechnologiesQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingLanguageTechnologiesListModel> Handle(GetListProgrammingLanguageTechnologiesQuery request, CancellationToken cancellationToken)
            {
                var models = await _programmingLanguageTechnologyRepository.GetListAsync(include: m => m.Include(c => c.ProgrammingLanguage),
                                                                                         index: request.PageRequest.Page,
                                                                                         size: request.PageRequest.PageSize);
                var mappedModels = _mapper.Map<ProgrammingLanguageTechnologiesListModel>(models);
                return mappedModels;
            }
        }
    }
}
