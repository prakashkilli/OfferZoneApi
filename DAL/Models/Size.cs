using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Size
    {
        public Size()
        {
            ProductSizes = new HashSet<ProductSize>();
        }

        public int SizeId { get; set; }
        public int? CategoryId { get; set; }
        public string SizeName { get; set; } = null!;

        public virtual Category? Category { get; set; }
        public virtual ICollection<ProductSize> ProductSizes { get; set; }
    }
}
