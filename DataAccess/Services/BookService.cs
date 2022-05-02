using BookStoreApi.DataAccess.Data_Transfer_Object;
using BookStoreApi.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.DataAccess.Services
{
    public class BookService : IService<Book, BookDTO>
    {
        public BookService(BookStoreDBContext bookStoreDBContext)
        {
            this._context = bookStoreDBContext;
        }
        private BookStoreDBContext _context;
        public async Task<Book> Add(BookDTO entity)
        {
            var book = new Book()
            {
                Author = entity.Author,
                Title = entity.Title,
                Genre = entity.Genre,
                Value = entity.Value
            };
           await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
               return book;
        }

        public async Task DeleteById(int Id)
        {
            var book =await _context?.Books?.FirstOrDefaultAsync(i => i.Id == Id);
            if(book == null)
            {
                throw new NullReferenceException();
            }
             _context?.Books?.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async IAsyncEnumerable<Book> Get()
        {
           var books = _context?.Books?.Include(o => o.Orders).AsNoTracking().AsAsyncEnumerable();
          // var books = _context?.Books.AsAsyncEnumerable();
            await foreach (Book book in books)
            {
                 yield return book;
            }
        }

        public async Task<Book> GetByID(int Id)
        {
            var book = await _context?.Books?.FirstOrDefaultAsync(b => b.Id == Id);
            return book;
        }

        public async Task<Book> UpdateById(BookDTO entity, int id)
        {
            var book = await _context?.Books?.FirstOrDefaultAsync(i => i.Id == id);
            if(book == null)
            {
                throw new NullReferenceException();
            }
            book.Title = entity.Title;
            book.Genre = entity.Genre;
            book.Author = entity.Author;
            book.Value = entity.Value;
            await _context?.SaveChangesAsync();
            return book;
        }
    }
}
