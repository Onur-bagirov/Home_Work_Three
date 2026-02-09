using EShopp.DAL.Context;
using EShopp.DAL.Respositories.Concretes;
using EShopp.Domain.Entities;
namespace EShopp.DAL.Respositories.Abstracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}