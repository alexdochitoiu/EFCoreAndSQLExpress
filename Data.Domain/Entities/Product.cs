using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Domain.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; private set; }

        [MaxLength(500)]
        public string Description { get; private set; }

        [Required]
        public int Price { get; private set; }
    }
}
