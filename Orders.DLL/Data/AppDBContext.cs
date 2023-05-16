using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;

namespace Orders.DLL.Data
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Item> Item { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Provider> Provider { get; set; }
    }
}
