using Microsoft.EntityFrameworkCore;
using CustomerLocationEF.Data.Models;

namespace CustomerLocationEF.Data.Context
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext() { }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }
        

        public DbSet<Customer> Customers { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Customer>()
                .HasKey(b => b.Id)
                .HasName("PrimaryKey_CustomerId");
        }
    }
}
