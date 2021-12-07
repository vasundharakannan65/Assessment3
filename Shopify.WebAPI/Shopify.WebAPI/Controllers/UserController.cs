using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopify.BL.BLInterfaces;
using Shopify.BL.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.WebAPI.Controllers
{
    //[Authorize(Roles="User")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userBL;

        public UserController(IUserBL userBL)
        {
            this._userBL = userBL;
        }

        //GetAllProducts
        [HttpGet]
        public async Task<IActionResult> GetListOfProducts()
        {
            try
            {
                var listOfProducts = await _userBL.GetListOfProducts();
                return Ok(listOfProducts);
            }
            catch (Exception e)
            {
                return StatusCode(statusCode: 500, e.Message);
            }

        }

    }
}
