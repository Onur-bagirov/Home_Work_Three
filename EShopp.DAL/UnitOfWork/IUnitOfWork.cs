using EShopp.DAL.Respositories.Abstracts;
namespace EShopp.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        Task<int> SaveChangesAsync();
    }
}
