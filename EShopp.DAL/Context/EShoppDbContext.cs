using EShopp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace EShopp.DAL.Context
{
    public class EShoppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Buy> Buys { get; set; }
    }
}
