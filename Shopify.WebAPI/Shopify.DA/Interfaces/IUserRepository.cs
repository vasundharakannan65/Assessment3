using Shopify.DA.Entities;
using Shopify.DA.MapperObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.DA.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<Product>> GetListOfProducts();
    }
}
