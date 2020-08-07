using LayeredArchitectureProject.Entity.Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitectureProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Product> Product { get; set; }
    }
}
