using BookStoreApi.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.DataAccess.Data_Transfer_Object
{
    public class OrderDTO
    {
        public Book Book { get; set; }
        public int BookId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
