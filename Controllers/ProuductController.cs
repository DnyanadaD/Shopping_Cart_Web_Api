using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart_API.Models;
using ShoppingCart_API.Services;

namespace ShoppingCart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProuductController : Controller
    {
        
        private ProductService _productServices;
        public ProuductController(ProductService Product)
        {
            _productServices=Product;
        }
        [HttpPost("SaveProduct")]
        public IActionResult SaveProduct(Product Product)
        {
            return Ok(_productServices.SaveProduct(Product));
        }

        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int ProductId)
        {
            return Ok(_productServices.DeleteProduct(ProductId));
        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProducte(Product Product)
        {
            return Ok(_productServices.UpdateProduct(Product));
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int ProductId)
        {
            return Ok(_productServices.GetProduct(ProductId));
        }

        [HttpGet("GetAllProduct()")]
        public List<Product> GetAllProduct()
        {
            return _productServices.GetAllProduct();
        }
         
    }
}
