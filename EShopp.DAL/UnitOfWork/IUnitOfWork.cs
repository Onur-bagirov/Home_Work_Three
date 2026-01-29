using EShopp.DAL.Respositories.Abstracts;
using System.Threading.Tasks;

namespace EShopp.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        Task<int> SaveChangesAsync();
    }
}
