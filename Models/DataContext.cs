//ef-db-context: gợi ý

using Microsoft.EntityFrameworkCore;

namespace ProductManager.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
 
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)   //1 product only 1 category
                .WithMany(c => c.Products) //1 category mutil product
                .HasForeignKey(p => p.CategoryId); // foreignKey of Product is CategoryId
 
            base.OnModelCreating(modelBuilder);
        }

    }
}
