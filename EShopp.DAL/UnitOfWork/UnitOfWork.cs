using EShopp.DAL.Context;
using EShopp.DAL.Respositories.Abstacts;
using EShopp.DAL.Respositories.Abstracts;
using EShopp.DAL.Respositories.Concretes;
namespace EShopp.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EShoppDbContext _context;
        public UnitOfWork(EShoppDbContext context)
        {
            _context = context;

            Products = new ProductRepository(_context);
            Categories = new CategoryRepository(_context);
            Orders = new OrderRepository(_context);
            Buys = new BuyRepository(_context);
        }
        public IProductRepository Products { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IOrderRepository Orders {  get; private set; }
        public IBuyRepository Buys { get; private set; }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
