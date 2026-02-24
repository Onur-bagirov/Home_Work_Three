using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace EShopp.DAL.Context
{
    public class EShoppDbContextFactory : IDesignTimeDbContextFactory<EShoppDbContext>
    {
        public EShoppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EShoppDbContext>();
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LASTDORAS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;";
            optionsBuilder.UseSqlServer(connectionString);
            return new EShoppDbContext(optionsBuilder.Options);
        }
    }
}