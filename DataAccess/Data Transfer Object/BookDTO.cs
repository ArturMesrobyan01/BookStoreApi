using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.DataAccess.Data_Transfer_Object
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string? Genre { get; set; }
        public string Value { get; set; }
    }
}
