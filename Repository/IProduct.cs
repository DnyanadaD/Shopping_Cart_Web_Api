using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart_API.Models;

namespace ShoppingCart_API.Repository
{
    public interface IProduct
    {
        public string SaveProduct(Product Product );
        public string UpdateProduct(Product Product);
        public string DeleteProduct(int ProductId);
        Product GetProduct(int ProductId);
        List<Product> GetAllProduct();
        
    }
}
