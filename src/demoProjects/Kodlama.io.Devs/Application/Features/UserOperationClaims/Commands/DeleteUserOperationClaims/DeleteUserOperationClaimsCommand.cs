using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaims
{
    public class DeleteUserOperationClaimsCommand:IRequest<DeletedUserOperationClaimDto>
    {
        public int Id { get; set; }
        public class DeleteUserOperationClaimsCommandHandler : IRequestHandler<DeleteUserOperationClaimsCommand, DeletedUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public DeleteUserOperationClaimsCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimsCommand request, CancellationToken cancellationToken)
            {
                var mappedUserOperationClaims = _mapper.Map<UserOperationClaim>(request);
                var addedResult = await _userOperationClaimRepository.AddAsync(mappedUserOperationClaims);
                var result = _mapper.Map<DeletedUserOperationClaimDto>(addedResult);
                return result;
            }
        }
    }
}
