﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductSizes = new HashSet<ProductSize>();
        }

        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<ProductSize> ProductSizes { get; set; }
    }
}
