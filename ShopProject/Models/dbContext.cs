using Microsoft.EntityFrameworkCore;

namespace ShopProject.Models
{
    public class dbContext:DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        public DbSet<Item> items { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Unit> Units { get; set; }

        public DbSet<Order> orders { get; set; }

        
    }
}
