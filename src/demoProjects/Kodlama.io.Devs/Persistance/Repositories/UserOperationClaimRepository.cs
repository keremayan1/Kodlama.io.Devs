using Application.Services.Repositories;
using Core.Persistance.Repositories;
using Core.Security.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, SQLContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(SQLContext context) : base(context)
        {
        }
    }

}
