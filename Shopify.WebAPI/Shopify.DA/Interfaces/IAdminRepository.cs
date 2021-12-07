using Shopify.DA.Entities;
using Shopify.DA.MapperObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.DA.Interfaces
{
    public interface IAdminRepository
    {
        public Task<List<ProductMapper>> GetListOfProducts();

        public void AddProduct(ProductMapper productMapper);

        public void AddProductImage(ImageMapper imageMapper);
    }
}
