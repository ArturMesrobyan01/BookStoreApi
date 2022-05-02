using BookStoreApi.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.DataAccess
{
    public class BookStoreDBContext : DbContext
    {

        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options)
        {

        }

        //method for one to one relationship
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>()
                .HasOne(b => b.Book)
                .WithMany(o => o.Orders)
                .HasForeignKey(id => id.BookId);

            builder.Entity<Order>()
                .HasOne(c => c.Customer)
                .WithMany(o => o.Orders)
                .HasForeignKey(id => id.CustomerId);
        }

        //to make changes in those tables
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
