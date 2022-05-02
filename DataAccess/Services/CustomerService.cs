using BookStoreApi.DataAccess.Data_Transfer_Object;
using BookStoreApi.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.DataAccess.Services
{
    public class CustomerService : IService<Customer, CustomerDTO>
    {
        private readonly BookStoreDBContext _context;

        public CustomerService(BookStoreDBContext context)
        {
            _context = context;
        }

        public async Task<Customer> Add(CustomerDTO entity)
        {
            var customer = new Customer()
            {
                Name = entity.Name,
                Surname = entity.Surname,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber
            };
           await _context.Customers.AddAsync(customer);
           await _context.SaveChangesAsync();

            return customer;
        }

        public async Task DeleteById(int Id)
        {
            var customer =await _context?.Customers?.FirstOrDefaultAsync(i => i.Id == Id); 
            if(customer == null)
            {
                throw new NullReferenceException();
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async IAsyncEnumerable<Customer> Get()
        {
            var _customers = _context?.Customers?.AsAsyncEnumerable();
            if(_customers == null)
            {
                throw new NullReferenceException();
            }
            await foreach(Customer customer in _customers)
            {
                yield return customer;
            }
        }

        public async Task<Customer> GetByID(int Id)
        {
            var customer = await _context?.Customers?.FirstOrDefaultAsync(e => e.Id == Id);
            if(customer == null)
            {
                throw new NullReferenceException();
            }
             return customer;
        }

        public async Task<Customer> UpdateById(CustomerDTO entity, int id)
        {
            var customer = await _context?.Customers?.FirstOrDefaultAsync(e => e.Id == id);
            if(customer == null)
            {
                throw new NullReferenceException();
            }
            customer.Name = entity.Name;
            customer.Surname = entity.Surname;
            customer.PhoneNumber = entity.PhoneNumber;
            customer.Email = entity.Email;

            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
