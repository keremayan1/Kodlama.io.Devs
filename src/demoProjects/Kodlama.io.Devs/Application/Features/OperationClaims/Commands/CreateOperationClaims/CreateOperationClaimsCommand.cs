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

namespace Application.Features.OperationClaims.Commands.CreateOperationClaims
{
    public class CreateOperationClaimsCommand:IRequest<CreatedOperationClaimsDto>
    {
        public string Name { get; set; }
        public class CreateOperationClaimsCommandHandler : IRequestHandler<CreateOperationClaimsCommand, CreatedOperationClaimsDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public CreateOperationClaimsCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<CreatedOperationClaimsDto> Handle(CreateOperationClaimsCommand request, CancellationToken cancellationToken)
            {
                var mappedOperationClaims = _mapper.Map<OperationClaim>(request);
                var addedResult = await _operationClaimRepository.AddAsync(mappedOperationClaims);
                var result = _mapper.Map<CreatedOperationClaimsDto>(addedResult);
                return result;
            }
        }
    }
}
