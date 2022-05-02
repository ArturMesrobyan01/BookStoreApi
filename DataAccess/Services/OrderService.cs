using BookStoreApi.DataAccess.Data_Transfer_Object;
using BookStoreApi.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.DataAccess.Services
{
    public class OrderService : IService<Order, OrderDTO>
    {
        private BookStoreDBContext _context;

        public OrderService(BookStoreDBContext context)
    {
            _context = context;
    }
        public async Task<Order> Add(OrderDTO entity)
        {
            var order = new Order()
            {
                Book = entity.Book,
                BookId = entity.BookId,
                Customer = entity.Customer,
                CustomerId = entity.CustomerId
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteById(int Id)
        {
            var order = await _context?.Orders?.FirstOrDefaultAsync(e => e.Id == Id);
            if(order == null)
            {
                throw new NullReferenceException();
            }
            _context.Orders?.Remove(order);
            await _context?.SaveChangesAsync();
        }

        public async IAsyncEnumerable<Order> Get()
        {
            var _orders = _context?.Orders?.AsAsyncEnumerable();
            if(_orders == null)
            {
                throw new NullReferenceException();
            }
            await foreach(Order order in _orders)
            {
                yield return order;
            }
        }

        public async Task<Order> GetByID(int Id)
        {
            var order = await _context?.Orders?.FirstOrDefaultAsync(i => i.Id == Id);
            if(order == null)
            {
                throw new NullReferenceException();
            }
            return order;
        }

        public async Task<Order> UpdateById(OrderDTO entity, int id)
        {
            var order = await _context?.Orders?.FirstOrDefaultAsync(i => i.Id == id);
            if (order == null)
            {
                throw new NullReferenceException();
            }
            order.Book = entity.Book;
            order.BookId = entity.BookId;
            order.Customer = entity.Customer;
            order.CustomerId = entity.CustomerId;
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
