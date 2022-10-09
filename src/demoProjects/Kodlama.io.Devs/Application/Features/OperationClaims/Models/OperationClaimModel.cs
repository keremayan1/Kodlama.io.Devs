using Application.Features.OperationClaims.Dtos;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Models
{
    public class OperationClaimModel:BasePageableModel
    {
        public IList<GetListOperationClaims> Items { get; set; }
    }
}
