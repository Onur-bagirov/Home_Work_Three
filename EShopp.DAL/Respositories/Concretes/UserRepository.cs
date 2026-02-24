using EShopp.DAL.Context;
using EShopp.DAL.Respositories.Abstracts;
using EShopp.Domain.Entities;
namespace EShopp.DAL.Respositories.Concretes
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(EShoppDbContext context) : base(context)
        {
        }
    }
}