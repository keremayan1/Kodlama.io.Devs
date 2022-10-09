using Application.Services.Repositories;
using Core.Persistance.Repositories;
using Core.Security.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class UserRepository : EfRepositoryBase<User, SQLContext>, IUserRepository
    {
        public UserRepository(SQLContext context) : base(context)
        {
        }
    }

}
