using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookStoreApi.DataAccess.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(30)]
        public string Name { get; set; }

        [Required, MaxLength(30)]
        public string Surname { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [JsonIgnore]
        public IEnumerable<Order>? Orders { get; set; }

    }
}
