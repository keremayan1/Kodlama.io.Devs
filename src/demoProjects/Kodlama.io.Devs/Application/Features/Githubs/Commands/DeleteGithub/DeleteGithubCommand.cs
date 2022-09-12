using Application.Features.Githubs.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Githubs.Commands.DeleteGithub
{
    public class DeleteGithubCommand:IRequest<DeletedGithubDto>
    {
        public int Id { get; set; }
        public class DeletedGithubCommandHandler : IRequestHandler<DeleteGithubCommand, DeletedGithubDto>
        {
            private readonly IGithubRepository _githubRepository;
            private readonly IMapper _mapper;

            public DeletedGithubCommandHandler(IGithubRepository githubRepository, IMapper mapper)
            {
                _githubRepository = githubRepository;
                _mapper = mapper;
            }

            public async Task<DeletedGithubDto> Handle(DeleteGithubCommand request, CancellationToken cancellationToken)
            {
                var getId = await _githubRepository.GetAsync(a => a.Id == request.Id);
                var deletedResult = await _githubRepository.DeleteAsync(getId);

                var result = _mapper.Map<DeletedGithubDto>(deletedResult);
                return result;
            }
        }
    }
}
