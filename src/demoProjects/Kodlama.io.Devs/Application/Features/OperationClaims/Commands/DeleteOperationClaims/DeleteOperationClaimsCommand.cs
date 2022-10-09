using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.DeleteOperationClaims
{
    public class DeleteOperationClaimsCommand:IRequest<DeletedOperationClaimsDto>
    {
        public int Id { get; set; }
        public class DeleteOperationClaimsCommandHandler : IRequestHandler<DeleteOperationClaimsCommand, DeletedOperationClaimsDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public DeleteOperationClaimsCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<DeletedOperationClaimsDto> Handle(DeleteOperationClaimsCommand request, CancellationToken cancellationToken)
            {
                var mappedOperationClaims = _mapper.Map<OperationClaim>(request);
                var deletedResult = await _operationClaimRepository.DeleteAsync(mappedOperationClaims);
                var result = _mapper.Map<DeletedOperationClaimsDto>(deletedResult);
                return result;
            }
        }
    }
}
