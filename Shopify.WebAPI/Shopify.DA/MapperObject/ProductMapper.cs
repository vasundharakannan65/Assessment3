using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.DA.MapperObject
{
    public class ProductMapper
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        public string CategoryName { get; set; }

        public string BrandName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public decimal Discount { get; set; }

        public DateTime ExpiryDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }
    }
}
