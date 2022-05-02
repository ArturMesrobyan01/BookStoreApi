using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStoreApi.DataAccess.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(70)]
        public string Title { get; set; }
        
        [Required, MaxLength(70)]
        public string Author { get; set; }

        [MaxLength(50)]
        public string? Genre { get; set; }

        [Required]
        public string Value { get; set; }

        [JsonIgnore]
        public IEnumerable<Order>? Orders { get; set; }


    }
}
