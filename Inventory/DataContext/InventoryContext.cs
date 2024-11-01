using Microsoft.EntityFrameworkCore;

namespace Inventory.DataContext
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) 
        {
            
        }


        public DbSet<Product> Products { get; set;}
        public DbSet<Document> Documents { get; set;}
        public DbSet<User> Users { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Hp EliteBook 745 G6"
                },
                new Product
                {
                    Id = 2,
                    Name = "Elders Schnapps"
                },
                new Product
                {
                    Id = 3,
                    Name = "Mac Book Pro 2024"
                },
                new Product
                {
                    Id = 4,
                    Name = "Iphone 16pro max"
                },
                new Product
                {
                    Id = 5,
                    Name = "Bottled Groudnut"
                },
                new Product
                {
                    Id = 6,
                    Name = "CWAY"
                }

            );
        }
    }
}
