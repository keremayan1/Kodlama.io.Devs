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

namespace Application.Features.Githubs.Commands.UpdateGithub
{
    public class UpdateGithubCommand:IRequest<UpdatedGithubDto>
    {
        public int Id { get; set; }
        public int DeveloperId { get; set; }
        public string GithubAddressName { get; set; }
        public class UpdatedGithubCommandHandler : IRequestHandler<UpdateGithubCommand, UpdatedGithubDto>
        {
            private readonly IGithubRepository _githubRepository;
            private readonly IMapper _mapper;

            public UpdatedGithubCommandHandler(IGithubRepository githubRepository, IMapper mapper)
            {
                _githubRepository = githubRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedGithubDto> Handle(UpdateGithubCommand request, CancellationToken cancellationToken)
            {
                var mappedGithub = _mapper.Map<Github>(request);
                
                var updatedResult = await _githubRepository.UpdateAsync(mappedGithub);

                var result = _mapper.Map<UpdatedGithubDto>(mappedGithub);

                return result;

               

            }
        }
    }
}
