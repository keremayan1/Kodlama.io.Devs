using Application.Features.Githubs.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Commands.CreateGithub
{
    public class CreateGithubCommand:IRequest<CreatedGithubDto>
    {
        public int DeveloperId { get; set; }
        public string GithubAddressName { get; set; }
        public class CreateGithubCommandHandler : IRequestHandler<CreateGithubCommand, CreatedGithubDto>
        {
            private readonly IGithubRepository _githubRepository;
            private readonly IMapper _mapper;

            public CreateGithubCommandHandler(IGithubRepository githubRepository, IMapper mapper)
            {
                _githubRepository = githubRepository;
                _mapper = mapper;
            }

            public async Task<CreatedGithubDto> Handle(CreateGithubCommand request, CancellationToken cancellationToken)
            {
                var mappedGithub = _mapper.Map<Github>(request);
                var addedResult = await _githubRepository.AddAsync(mappedGithub);

                var result = _mapper.Map<CreatedGithubDto>(addedResult);
                return result;
            }
        }
    }
}
