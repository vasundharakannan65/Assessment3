using CustomIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shopify.BL.BLInterfaces;
using Shopify.BL.Logics;
using Shopify.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shopify.WebAPI.Controllers
{
    //[Authorize(Roles = "Administrator")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IAdminBL _adminBL;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(IAdminBL adminBL, UserManager<ApplicationUser> userManager)
        {
            this._adminBL = adminBL;
            this._userManager = userManager;
        }


        //GetAllProducts
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var listOfProducts = await _adminBL.GetAllProducts();
                return Ok(listOfProducts);
            }
            catch (Exception e)
            {
                //404 - resource that does not exist
                return StatusCode(statusCode: 404, e.Message);
            }

        }

        //AddProduct 
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductViewModel productViewModel)
        {
            try
            {
                //string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                //ApplicationUser user = await this._userManager.FindByIdAsync(userId);

                //_adminBL.AddProduct(productViewModel, user);
                _adminBL.AddProduct(productViewModel);
                return Ok();
            }
            catch (Exception e)
            {
                //400 - something wrong in the request data
                return StatusCode(statusCode: 400, e.Message);
            }
        }

        //AddProductImage
        [HttpPost]
        public IActionResult AddProductImage([FromForm]ImageViewModel imageViewModel)
        {
            try
            {
                _adminBL.AddProductImage(imageViewModel);
                return Ok();
            }
            catch (Exception e)
            {
                //400 - something wrong in the request data
                return StatusCode(statusCode: 400, e.Message);
            }
        }
    }
}
