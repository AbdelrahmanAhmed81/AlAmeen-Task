using Application.Contexts;
using Application.Repositories.Interfaces;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext context;

        public CustomerRepository(AppDbContext _context)
        {
            context = _context;
        }
        public async Task<Customer> Create(Customer customer)
        {
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
            return customer;
        }

        public async Task<IList<Customer>> GetAll()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<Customer> Update(Customer customer)
        {
            var oldCustomer = await context.Customers.FindAsync(customer.CustomerId);
            if (oldCustomer != null)
            {
                context.Customers.Attach(customer);
                oldCustomer.FirstName = customer.FirstName;
                oldCustomer.LastName = customer.LastName;
                oldCustomer.Email = customer.Email;
                oldCustomer.Phone = customer.Phone;
                oldCustomer.IsActive = customer.IsActive;
                await context.SaveChangesAsync();
                return oldCustomer;
            }
            else
                throw new InvalidOperationException($"no existing customer with id = {customer.CustomerId}");

        }
    }
}
