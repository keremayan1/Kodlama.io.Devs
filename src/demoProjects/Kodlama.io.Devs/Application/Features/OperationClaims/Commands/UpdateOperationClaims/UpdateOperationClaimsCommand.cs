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

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaims
{
    public class UpdateOperationClaimsCommand:IRequest<UpdatedOperationClaimsDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateOperationClaimsCommandHandler : IRequestHandler<UpdateOperationClaimsCommand, UpdatedOperationClaimsDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public UpdateOperationClaimsCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedOperationClaimsDto> Handle(UpdateOperationClaimsCommand request, CancellationToken cancellationToken)
            {
                var mappedOperationClaims = _mapper.Map<OperationClaim>(request);
                var updatedResult = await _operationClaimRepository.UpdateAsync(mappedOperationClaims);
                var result = _mapper.Map<UpdatedOperationClaimsDto>(updatedResult);
                return result;
            }
        }
    }
}
