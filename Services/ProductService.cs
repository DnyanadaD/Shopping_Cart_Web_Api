using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart_API.Models;
using ShoppingCart_API.Repository;

namespace ShoppingCart_API.Services
{
    public class ProductService
    {
        public IProduct _ProductRepository;

        public  ProductService(IProduct Product)
        {
             _ProductRepository = Product ;
        }
        
         public string SaveProduct(Product Product)
        {
            return _ProductRepository.SaveProduct(Product);
        }
        public string DeleteProduct(int ProductId)
        {
            return _ProductRepository.DeleteProduct(ProductId);
        }
        public string UpdateProduct(Product Product)
        {
            return _ProductRepository.UpdateProduct(Product);
        }
        public Product GetProduct(int ProductId)
        {
            return _ProductRepository.GetProduct(ProductId);
        }
        public List<Product> GetAllProduct()
        {
            return _ProductRepository.GetAllProduct();
        }
         
    }
}
