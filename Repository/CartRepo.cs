using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCart_API.Data;
using ShoppingCart_API.Models;

namespace ShoppingCart_API.Repository
{
    public class CartRepo : ICart
    {
        private ShoppingCartDbContext _ShoppingCartDb;
        public CartRepo(ShoppingCartDbContext ShoppingCartDb)
        {
            _ShoppingCartDb = ShoppingCartDb;
        }
        public string DeleteCart(int CartId)
        {
            string msg = "";
            Cart deleteCart = _ShoppingCartDb.Cart.Find(CartId);
            if (deleteCart != null)
            {
                _ShoppingCartDb.Cart.Remove(deleteCart);
                _ShoppingCartDb.SaveChanges();
                msg = "Deleted";
            }
            return msg;
        }

        public List<Cart> GetAllCart()
        {
            List<Cart> carts = _ShoppingCartDb.Cart.ToList();
            return carts;
        }

        public Cart GetCart(int CartId)
        {
            Cart carts = _ShoppingCartDb.Cart.Find(CartId);
            return carts;
        }

        public string SaveCart(Cart cart)
        {
            _ShoppingCartDb.Cart.Add(cart);
            _ShoppingCartDb.SaveChanges();
            return "Saved"; ;
        }

        public string UpdateCart(Cart cart)
        {
            _ShoppingCartDb.Entry(cart).State = EntityState.Modified;
            _ShoppingCartDb.SaveChanges();
            return "Updated";
        }
    }
}
