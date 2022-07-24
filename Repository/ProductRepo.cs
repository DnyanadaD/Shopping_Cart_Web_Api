using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCart_API.Data;
using ShoppingCart_API.Models;

namespace ShoppingCart_API.Repository
{
    public class ProductRepo : IProduct
    {
        private ShoppingCartDbContext _ShoppingCartDb;

        public ProductRepo(ShoppingCartDbContext ShoppingCartDb)
        {
            _ShoppingCartDb = ShoppingCartDb;
        }
        public string DeleteProduct(int ProductId)
        {
            string msg = "";
            Product delete = _ShoppingCartDb.Product.Find(ProductId);//storing the details of the Product in the obj 
            if (delete != null)
            {
                _ShoppingCartDb.Product.Remove(delete);
                _ShoppingCartDb.SaveChanges();
                msg = "Deleted";
            }
            return msg;
        }

        public List<Product> GetAllProduct()
        {
            List<Product> product = _ShoppingCartDb.Product.ToList();
            return product;
        }

        public Product GetProduct(int ProductId)
        {
            Product product = _ShoppingCartDb.Product.Find(ProductId);
            return product;
        }

        public string SaveProduct(Product Product)
        {
            _ShoppingCartDb.Product.Add(Product);
            _ShoppingCartDb.SaveChanges();
            return "Saved";
        }

        public string UpdateProduct(Product Product)
        {
            _ShoppingCartDb.Entry(Product).State = EntityState.Modified;
            _ShoppingCartDb.SaveChanges();
            return "Updated";
        }
    }
}
