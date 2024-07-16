using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
            Sizes = new HashSet<Size>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }
    }
}
