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
                new Customer() { CustomerId = 1 , FirstName = "Abdelrahman" , LastName = "Ahmed" , Email = "Abdelrahman@yahoo.com" , Phone = "01555447488" , IsActive = true } ,
                new Customer() { CustomerId = 2 , FirstName = "Mohammed" , LastName = "Saeed" , Email = "Mohammed@yahoo.com" , Phone = "01531157898" , IsActive = true }
                );

            modelBuilder.Entity<CustomerAddress>().HasData(
                new CustomerAddress() { CustomerAddressId = 1 , CustomerId = 1 , AddressLine1 = "45A Al Giza St" , AddressLine2 = "Giza Square" , City = "Giza" , State = "Giza" , Country = "Egypt" , PostalCode = "26566" , IsBillingAddress = true , IsShippingAddress = false } ,
                new CustomerAddress() { CustomerAddressId = 2 , CustomerId = 1 , AddressLine1 = "35B mohammed ismail St" , AddressLine2 = "Al Haram" , City = "Giza" , State = "Giza" , Country = "Egypt" , PostalCode = "54223" , IsBillingAddress = false , IsShippingAddress = true } ,
                new CustomerAddress() { CustomerAddressId = 3 , CustomerId = 2 , AddressLine1 = "5C mathaf al matrya" , AddressLine2 = "Ain Shams" , City = "Cairo" , State = "Cairo" , Country = "Egypt" , PostalCode = "45722" , IsBillingAddress = true , IsShippingAddress = true }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductId = 1 , Name = "Chair" , Price = 5000 , Description = "Gaming Chair" } ,
                new Product() { ProductId = 2 , Name = "Desk" , Price = 7500 , Description = "Modern desk" } ,
                new Product() { ProductId = 3 , Name = "Table" , Price = 6500 , Description = "Wooden Table" }
                );

            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail() { OrderDetailId = 1 , OrderId = 1 , ProductId = 1 , Quantity = 5 , Price = 5000 , Total = 25000 , Tax = 3500 } ,
                new OrderDetail() { OrderDetailId = 2 , OrderId = 1 , ProductId = 2 , Quantity = 2 , Price = 7500 , Total = 15000 , Tax = 2100 } ,
                new OrderDetail() { OrderDetailId = 3 , OrderId = 2 , ProductId = 3 , Quantity = 6 , Price = 6500 , Total = 39000 , Tax = 5460 }
                );

            modelBuilder.Entity<Order>().HasData(
                new Order() { OrderId = 1 , Status = "Deliverd" , CustomerId = 1 } ,
                new Order() { OrderId = 2 , Status = "Waiting" , CustomerId = 2 }
                );

            modelBuilder.Entity<OrderBillingAddress>().HasData(
                new OrderBillingAddress() { OrderBillingAddressId = 1 , AddressLine1 = "45A Al Giza St" , AddressLine2 = "Giza Square" , City = "Giza" , State = "Giza" , Country = "Egypt" , PostalCode = "26566" , OrderId = 1 } ,
                new OrderBillingAddress() { OrderBillingAddressId = 2 , AddressLine1 = "35B mohammed ismail St" , AddressLine2 = "Al Haram" , City = "Giza" , State = "Giza" , Country = "Egypt" , PostalCode = "54223" , OrderId = 2 }
                );

            modelBuilder.Entity<OrderShippingAddress>().HasData(
                new OrderShippingAddress() { OrderShippingAddressId = 1 , AddressLine1 = "5C mathaf al matrya" , AddressLine2 = "Ain Shams" , City = "Cairo" , State = "Cairo" , Country = "Egypt" , PostalCode = "45722" , OrderId = 1 } ,
                new OrderShippingAddress() { OrderShippingAddressId = 2 , AddressLine1 = "35B mohammed ismail St" , AddressLine2 = "Al Haram" , City = "Giza" , State = "Giza" , Country = "Egypt" , PostalCode = "54223" , OrderId = 2 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
