using Microsoft.EntityFrameworkCore;
using Sales.Models;

namespace Sales
{
    public class ApiDbContext:DbContext
    {
        public DbSet<Item> Items { get; set; }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Invoice_Details> Invoice_Details { get; set; }
       

        public ApiDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Invoice_Details>().HasKey(vf => new { vf.Item_ID, vf.Invoice_ID });

            base.OnModelCreating(modelBuilder);
        }
    }
}