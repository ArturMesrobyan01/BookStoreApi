using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.DataAccess.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Book Book { get; set; }
        [Required]
        public int BookId { get; set; }

        [Required]
        public Customer Customer { get; set; }
        [Required]
        public int CustomerId { get; set; }

    }
}
