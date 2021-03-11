using Microsoft.EntityFrameworkCore;
using ShopKzLINQHomework.Domain;

namespace ShopKzLINQHomework.DataAccessLayer
{
    public class ShopContext : DbContext
    {
        public ShopContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Product { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Manufacturer> Manufacturer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6543DI3; Database=ShopKZ; Trusted_Connection = true;");
        }
    }
}
