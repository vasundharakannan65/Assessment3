using Shopify.BL.BLInterfaces;
using Shopify.DA.Entities;
using Shopify.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.BL.Logics
{
    public class UserBL : IUserBL
    {
        private readonly IUserRepository _userRepository;

        public UserBL(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<IEnumerable<Product>> GetListOfProducts()
        {
            return await _userRepository.GetListOfProducts();
        }
    }
}
