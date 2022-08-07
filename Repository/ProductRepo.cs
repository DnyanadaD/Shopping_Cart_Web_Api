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

        #region ProductRepo
        /// <summary>
        /// ProductRepo Constuctor
        /// </summary>
        /// <param name="ShoppingCartDb"></param>
        public ProductRepo(ShoppingCartDbContext ShoppingCartDb)
        {
            _ShoppingCartDb = ShoppingCartDb;
        }
        #endregion


        #region DeleteProduct
        /// <summary>
        /// Method for deleting product
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public string DeleteProduct(int ProductId)
        {
            string msg = "";
            Product delete = _ShoppingCartDb.Product.Find(ProductId);//storing the details of the Product in the obj 
            try
            {
                if (delete != null)
                {
                    _ShoppingCartDb.Product.Remove(delete);
                    _ShoppingCartDb.SaveChanges();
                    msg = "Deleted";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return msg;
        }
        #endregion


        #region GetAllProduct
        /// <summary>
        /// Method to get all the product
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProduct()
        {
           
         List<Product> product = _ShoppingCartDb.Product.ToList();
            return product;
        }
        #endregion


        #region GetProduct
        /// <summary>
        /// Method to get product by id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public Product GetProduct(int ProductId)
        {
            try
            {
                Product product = _ShoppingCartDb.Product.Find(ProductId);
                return product;
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion


        #region SaveProduct
        /// <summary>
        /// Method to save the product details
        /// </summary>
        /// <param name="Product"></param>
        /// <returns></returns>
        public string SaveProduct(Product Product)
        {
            try
            {
                _ShoppingCartDb.Product.Add(Product);
                _ShoppingCartDb.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }
            return "Saved";
        }
        #endregion


        #region UpdateProduct
        /// <summary>
        /// Method to Update product details
        /// </summary>
        /// <param name="Product"></param>
        /// <returns></returns>
        public string UpdateProduct(Product Product)
        {
            try
            {
                _ShoppingCartDb.Entry(Product).State = EntityState.Modified;
                _ShoppingCartDb.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }
            return "Updated";
        }
        #endregion

    }
}
