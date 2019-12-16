using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopping.Core.ServiceInterfaces;
using Shopping.ListModels;
using Shopping.Data.Models;

namespace Shopping.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public JsonResult GetProductById(int productId)
        {
            var result = productService.GetProductById(productId);
            return Json(result);
        }

        [HttpPost]
        public JsonResult GetAllProducts()
        {
            var productList = new List<ProductListModel>();
            var result = productService.GetAllProducts().ToList();

            foreach (var item in result)
            {
                productList.Add(new ProductListModel { Value = item.ProductId, Text = item.ProductName });
            }
            return Json(productList);
        }

    }
}