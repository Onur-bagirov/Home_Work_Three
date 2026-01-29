using EShopp.DAL.Context;
using EShopp.DAL.Respositories.Abstracts;
using EShopp.Domain.Entities;

namespace EShopp.DAL.Respositories.Concretes
{
    public class ProductRepository
        : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(EShoppDbContext context) : base(context) { }
    }
}