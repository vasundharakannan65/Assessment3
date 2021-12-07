using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Shopify.DA.Data;
using Shopify.DA.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Shopify.DA.MapperObject;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Shopify.DA.Entities;

namespace Shopify.DA.Repositories
{
    public class AdminRepository : IAdminRepository
    {

        private readonly IConfiguration _configuration;
        //private readonly IMapper _mapper;
        private readonly EcommerceSystemContext _db;




        public AdminRepository(IConfiguration configuration, EcommerceSystemContext db)
        {
            this._configuration = configuration;
            this._db = db;
            //this._mapper = mapper;
        }
        
        public async Task<List<ProductMapper>> GetListOfProducts()
        {
            using IDbConnection dbConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string sp = "[dbo].[SP_GetAllProducts]";

            return await Task.FromResult(dbConnection.Query<ProductMapper>(sp, commandType: CommandType.StoredProcedure).ToList());

        }

        public void AddProduct(ProductMapper productMapper)
        {
           
            //Product productObject = _mapper.Map<ProductMapper, Product>(product);
            Product product = new();

            product.Name = productMapper.Name;
            product.CategoryId = productMapper.CategoryId;
            product.BrandId = productMapper.BrandId;
            product.Price = productMapper.Price;
            product.Description = productMapper.Description;
            product.Discount = productMapper.Discount;
            product.Stock = productMapper.Stock;
            product.ExpiryDate = productMapper.ExpiryDate;
            product.CreatedAt = productMapper.CreatedAt;
            product.CreatedBy = productMapper.CreatedBy;


            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void AddProductImage(ImageMapper image)
        {
            GetImageMapper obj = this.ImageProcess(image);
            //ProductImage imageObject = _mapper.Map<GetImageMapper, ProductImage>(obj);
            ProductImage objImage = new();

            objImage.ProductId = obj.ProductId;
            objImage.Image = obj.Image;
            //objImage.FileName = DateTime.
            objImage.IsActive = obj.IsActive;
            objImage.Version = obj.Version;
            objImage.CreatedAt = DateTime.UtcNow;
            objImage.CreatedBy = Guid.Parse("3C8DAB0F-3DE0-46D7-A879-08D9B894C671");

            _db.ProductImages.Add(objImage);

            //add createdby,createdat
            _db.SaveChanges();
        }

        //display and saving img
        public GetImageMapper ImageProcess(ImageMapper image)
        {
            GetImageMapper obj = new();

            //user uploaded file name
            string fileName = null;

            //name that we provide 
            string imageName = null;

            //count = 0;
            //version number
            int version = 0;

            if (image.File != null)
            {
                fileName = image.File.FileName;
                int count = 0;

                //
                count = _db.ProductImages.GroupBy(x => x.ProductId).Count();

                if(count >= 0)
                {
                    count += 1;
                }

                version = count;

                var tempFile = _configuration.GetSection("AppSettings").GetSection("ImagePath").Value;

                using (var fs = File.Create(tempFile))
                {
                    image.File.CopyToAsync(fs);
                }

                //configuration.GetValue<string>("MySettings:DbConnection");
                imageName = Path.Combine(_configuration.GetSection("AppSettings").GetSection("ImagePath").Value.ToString(),fileName,version.ToString());

                obj.Image = imageName;
                obj.Version = version;
                //obj.FileName = fileName;
                obj.ProductId = image.ProductId;
                obj.IsActive = false;

                return obj;
            }

            
            return obj;
        }

 
    }
}
