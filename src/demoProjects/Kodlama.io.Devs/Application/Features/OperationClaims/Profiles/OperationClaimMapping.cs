using Application.Features.OperationClaims.Commands.CreateOperationClaims;
using Application.Features.OperationClaims.Commands.DeleteOperationClaims;
using Application.Features.OperationClaims.Commands.UpdateOperationClaims;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using Application.Features.OperationClaims.Queries.GetListOperationClaims;
using AutoMapper;
using Core.Persistance.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Profiles
{
    public class OperationClaimMapping:Profile
    {
        public OperationClaimMapping()
        {
            CreateMap<OperationClaim, CreatedOperationClaimsDto>().ReverseMap();
            CreateMap<OperationClaim, CreateOperationClaimsCommand>().ReverseMap();

            CreateMap<OperationClaim, UpdatedOperationClaimsDto>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaimsCommand>().ReverseMap();

            CreateMap<OperationClaim, DeletedOperationClaimsDto>().ReverseMap();
            CreateMap<OperationClaim, DeleteOperationClaimsCommand>().ReverseMap();

            CreateMap<IPaginate<OperationClaim>, OperationClaimModel>().ReverseMap();
            CreateMap<OperationClaim, GetListOperationClaimsQuery>().ReverseMap();
            CreateMap<OperationClaim, GetListOperationClaims>().ReverseMap();

        }
    }
}
