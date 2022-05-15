#nullable disable
using Make_Orders.Models;
using Microsoft.EntityFrameworkCore;

namespace Make_Orders.Data
{
    public class Make_OrdersContext : DbContext
    {
        public Make_OrdersContext(DbContextOptions<Make_OrdersContext> options)
            : base(options)
        {
        }

        public Make_OrdersContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>()
                .HasMany<Items>(s => s.items)
                .WithOne(o => o.order)
                .HasForeignKey(o => o.OrdersID)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Orders> Orders { get; set; }

        public DbSet<Items> Items { get; set; }


    }
}
