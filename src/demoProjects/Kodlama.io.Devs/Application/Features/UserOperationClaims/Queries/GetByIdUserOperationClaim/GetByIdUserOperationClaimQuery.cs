using Application.Features.UserOperationClaims.Dtos;
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

namespace Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim
{
    public class GetByIdUserOperationClaimQuery:IRequest<UserOperationClaimModel>
    {
        public int UserId { get; set; }
        public PageRequest PageRequest { get; set; }
        public class GetByIdUserOperationClaimQueryHandler : IRequestHandler<GetByIdUserOperationClaimQuery, UserOperationClaimModel>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public GetByIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<UserOperationClaimModel> Handle(GetByIdUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                var models = await _userOperationClaimRepository.GetListAsync(u=>u.UserId==request.UserId,include: u => u.Include(x => x.User).Include(x => x.OperationClaim), index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                var result = _mapper.Map<UserOperationClaimModel>(models);
                return result;
            }
        }
    }
}
