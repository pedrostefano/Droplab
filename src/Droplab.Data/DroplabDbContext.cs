using Droplab.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Droplab.Data
{
    public class DroplabDbContext: DbContext
    {

        public DroplabDbContext(DbContextOptions options) : base(options)
        {             
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrdersItems { get; set; }
        public DbSet<State> States { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>().ToTable("T_ORDER");
            modelBuilder.Entity<OrderItem>().ToTable("T_ORDER_ITEM");
            modelBuilder.Entity<State>().ToTable("T_STATE");

        }
    }
}