using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Shopify.DA.Entities;
using Shopify.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.DA.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<IEnumerable<Product>> GetListOfProducts()
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "[dbo].[SP_GetAllProducts]";

            return await Task.FromResult(dbConnection.Query<Product>(sp, commandType: CommandType.StoredProcedure).ToList());

        }
    }
}
