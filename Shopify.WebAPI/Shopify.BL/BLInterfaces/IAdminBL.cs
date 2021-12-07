using CustomIdentity;
using Shopify.BL.ViewModels;
using Shopify.DA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.BL.BLInterfaces
{
    public interface IAdminBL
    {
        public Task<List<ProductViewModel>> GetAllProducts();

        //create viewmodel for user
        public void AddProduct(ProductViewModel productViewModel);

        public void AddProductImage(ImageViewModel imageViewModel);
    }
}
