using EShopp.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace EShopp.DAL.Context
{
    public class EShoppDbContext : IdentityDbContext<User>
    {
        public EShoppDbContext(DbContextOptions<EShoppDbContext> options) : base(options) 
        { 
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Buy> Buys { get; set; }
    }
}