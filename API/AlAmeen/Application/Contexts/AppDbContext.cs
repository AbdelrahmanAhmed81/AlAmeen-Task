using Microsoft.EntityFrameworkCore;
using Domain.Entites;

namespace Application.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderShippingAddress> OrderShippingAddresses { get; set; }
        public DbSet<OrderBillingAddress> OrderBillingAddresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer() { FirstName = "Abdelrahman" , LastName = "Ahmed" , Email = "Abdelrahman@yahoo.com" , Phone = "01555447488" , IsActive = true } ,
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
