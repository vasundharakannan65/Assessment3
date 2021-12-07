
using Shopify.DA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.BL.BLInterfaces
{
    public interface IUserBL
    {
        public Task<IEnumerable<Product>> GetListOfProducts();
    }
}
