using EShopp.DAL.Context;
using EShopp.DAL.Respositories.Abstracts;
using EShopp.Domain.Entities;
namespace EShopp.DAL.Respositories.Concretes
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(EShoppDbContext context) : base(context)
        {
        }
    }
}