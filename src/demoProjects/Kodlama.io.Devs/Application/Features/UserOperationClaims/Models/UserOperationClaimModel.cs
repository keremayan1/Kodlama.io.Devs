using Application.Features.UserOperationClaims.Dtos;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Models
{
    public class UserOperationClaimModel:BasePageableModel
    {
        public IList<GetListUserOperationClaimDto> Items { get; set; }
    }
}
