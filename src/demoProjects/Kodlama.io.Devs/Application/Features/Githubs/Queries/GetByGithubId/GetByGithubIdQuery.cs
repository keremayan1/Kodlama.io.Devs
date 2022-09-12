using Application.Features.Githubs.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Queries.GetByGithubId
{
    public class GetByGithubIdQuery:IRequest<GetByGithubIdDto>
    {
        public int Id { get; set; }
        public class GetByGithubIdQueryHandler : IRequestHandler<GetByGithubIdQuery, GetByGithubIdDto>
        {
            private readonly IGithubRepository _githubRepository;
            private readonly IMapper _mapper;

            public GetByGithubIdQueryHandler(IGithubRepository githubRepository, IMapper mapper)
            {
                _githubRepository = githubRepository;
                _mapper = mapper;
            }

            public async Task<GetByGithubIdDto> Handle(GetByGithubIdQuery request, CancellationToken cancellationToken)
            {
                var getId = await _githubRepository.GetAsync2(x => x.Id == request.Id, include: m => m.Include(c => c.Developer));
                var result = _mapper.Map<GetByGithubIdDto>(getId);
                return result;
            }
        }
    }
}
