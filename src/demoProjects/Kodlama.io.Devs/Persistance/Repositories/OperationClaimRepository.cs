using Application.Services.Repositories;
using Core.Persistance.Repositories;
using Core.Security.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, SQLContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(SQLContext context) : base(context)
        {
        }
    }

}
