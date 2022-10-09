using Application.Features.OperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries.GetListOperationClaims
{
    public class GetListOperationClaimsQuery:IRequest<OperationClaimModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListOperationClaimsQueryHandler : IRequestHandler<GetListOperationClaimsQuery, OperationClaimModel>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public GetListOperationClaimsQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<OperationClaimModel> Handle(GetListOperationClaimsQuery request, CancellationToken cancellationToken)
            {
                var models = await _operationClaimRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                var result = _mapper.Map<OperationClaimModel>(models);
                return result;
            }
        }
    }
}
