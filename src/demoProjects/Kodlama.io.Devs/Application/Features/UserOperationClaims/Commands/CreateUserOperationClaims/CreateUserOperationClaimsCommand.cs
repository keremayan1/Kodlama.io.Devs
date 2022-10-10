using Application.Features.OperationClaims.Dtos;
using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaims
{
    public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>,ISecuredRequest
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public string[] Roles { get; } = { "Admin" };

        public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
                var addedResult = await _userOperationClaimRepository.AddAsync(mappedUserOperationClaim);
                var result = _mapper.Map<CreatedUserOperationClaimDto>(addedResult);
                return result;
            }
        }
    }
}
