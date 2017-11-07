using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EnsureThat;

namespace Data.Domain.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; private set; }

        [MaxLength(50)]
        public string Title { get; private set; }
        
        public List<Product> Products { get; private set; }

        [Required]
        public string DistributorName { get; private set; }

        public static Category Create(string title, string distributorName)
        {
            Ensure.That(title).IsNotNullOrEmpty();
            Ensure.That(distributorName).IsNotNullOrEmpty();
            var instance = new Category
            {
                Id = Guid.NewGuid(),
                Products = new List<Product>()
            };
            instance.Update(title, distributorName);
            return instance;
        }

        public void Update(string title, string distributorName)
        {
            Ensure.That(title).IsNotNullOrEmpty();
            Ensure.That(distributorName).IsNotNullOrEmpty();
            Title = title;
            DistributorName = distributorName;
        }
    }
}
