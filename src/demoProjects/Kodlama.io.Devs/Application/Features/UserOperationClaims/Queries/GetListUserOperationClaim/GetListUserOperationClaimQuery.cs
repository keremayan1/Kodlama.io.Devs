using Application.Features.UserOperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim
{
    public class GetListUserOperationClaimQuery : IRequest<UserOperationClaimModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery, UserOperationClaimModel>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<UserOperationClaimModel> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                var models = await _userOperationClaimRepository.GetListAsync(include: u => u.Include(x => x.User).Include(x => x.OperationClaim), index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                var result = _mapper.Map<UserOperationClaimModel>(models);
                return result;
            }
        }
    }
}
