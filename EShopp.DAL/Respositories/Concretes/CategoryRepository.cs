using EShopp.DAL.Context;
using EShopp.DAL.Respositories.Abstracts;
using EShopp.Domain.Entities;

namespace EShopp.DAL.Respositories.Concretes;
public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(EShoppDbContext context) : base(context)
    {
    }
}
