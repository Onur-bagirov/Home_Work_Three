using EShopp.DAL.Context;
using EShopp.DAL.Respositories.Abstacts;
namespace EShopp.DAL.Respositories.Concretes
{
    public class BuyRepository : GenericRepository<Buy>,IBuyRepository    
    {
        public BuyRepository(EShoppDbContext context) : base(context)
        {
        }
    }
}   