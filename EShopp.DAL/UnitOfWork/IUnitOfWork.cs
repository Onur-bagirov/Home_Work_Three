using EShopp.DAL.Respositories.Abstacts;
using EShopp.DAL.Respositories.Abstracts;
namespace EShopp.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        IBuyRepository Buys { get; }
        IUserRepository Users { get; }
        Task<int> SaveChangesAsync();
    }
}
