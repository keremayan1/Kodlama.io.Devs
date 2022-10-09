using Application.Services.Repositories;
using Core.Persistance.Repositories;
using Core.Security.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, SQLContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(SQLContext context) : base(context)
        {
        }
    }

}
