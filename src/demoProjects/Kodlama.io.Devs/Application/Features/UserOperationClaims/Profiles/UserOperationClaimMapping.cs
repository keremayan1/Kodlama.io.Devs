using Application.Features.OperationClaims.Dtos;
using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaims;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaims;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using AutoMapper;
using Core.Persistance.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Profiles
{
    public class UserOperationClaimMapping:Profile
    {
        public UserOperationClaimMapping()
        {
            CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();

            CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, DeleteUserOperationClaimsCommand>().ReverseMap();

            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimModel>().ReverseMap();
            CreateMap<UserOperationClaim, GetListUserOperationClaimDto>().ForMember(x => x.Id, opt => opt.MapFrom(x => x.User.Id))
                                                                        .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
                                                                        .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.User.LastName))
                                                                        .ForMember(x => x.UserOperationClaimName, opt => opt.MapFrom(x => x.OperationClaim.Name)).ReverseMap();
        }
    }
}
