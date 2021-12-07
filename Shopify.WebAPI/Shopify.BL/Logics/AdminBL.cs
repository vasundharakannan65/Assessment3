//using AutoMapper;
using CustomIdentity;
using Shopify.BL.BLInterfaces;
using Shopify.BL.ViewModels;
using Shopify.DA.Entities;
using Shopify.DA.Interfaces;
using Shopify.DA.MapperObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.BL.Logics
{
    public class AdminBL : IAdminBL
    {
        private readonly IAdminRepository _adminRepository;
        //private readonly IMapper _mapper;

        public AdminBL(IAdminRepository adminRepository)
        {
            this._adminRepository = adminRepository;
            //this._mapper = mapper;
        }

        public async Task<List<ProductViewModel>> GetAllProducts()
        {
            //var theListOfObjectsB = (from e in theListOfObjectsA select new ObjectB { prop1 = e.prop1, prop2 = e.prop2 }).ToList();
            var mapper = await _adminRepository.GetListOfProducts();

            var viewmodel = (from m in mapper
                             select new ProductViewModel
                             {
                                 Name = m.Name,
                                 BrandName = m.BrandName,
                                 CategoryName = m.CategoryName,
                                 Price = m.Price,
                                 Description = m.Description,
                                 Stock = m.Stock,
                                 Discount = m.Discount,
                                 ExpiryDate = m.ExpiryDate

                             }).ToList();

            return viewmodel;
            //convert
            //return await _adminRepository.GetListOfProducts();
        }

        public void AddProduct(ProductViewModel productViewModel)
        {
            //ProductMapper productMapper = _mapper.Map<ProductViewModel, ProductMapper>(productViewModel);
            ProductMapper productMapper = new();

            productMapper.Name = productViewModel.Name;
            productMapper.CategoryId = productViewModel.CategoryId;
            productMapper.BrandId = productViewModel.BrandId;
            productMapper.Price = productViewModel.Price;
            productMapper.Description = productViewModel.Description;
            productMapper.Discount = productViewModel.Discount;
            productMapper.Stock = productViewModel.Stock;
            productMapper.ExpiryDate = productViewModel.ExpiryDate;
            productMapper.CreatedAt = DateTime.UtcNow;
            productMapper.CreatedBy = Guid.Parse("3C8DAB0F-3DE0-46D7-A879-08D9B894C671");

            _adminRepository.AddProduct(productMapper);
        }

        public void AddProductImage(ImageViewModel imageViewModel)
        {
            //ImageMapper imageMapper = _mapper.Map<ImageViewModel, ImageMapper>(imageViewModel);
            ImageMapper imageMapper = new();

            imageMapper.ProductId = imageViewModel.ProductId;
            imageMapper.File = imageViewModel.File;

            _adminRepository.AddProductImage(imageMapper);
        }
    }
}
