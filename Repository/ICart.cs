using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart_API.Models;

namespace ShoppingCart_API.Repository
{
    public interface ICart
    {
        public string SaveCart(Cart cart);
        public string UpdateCart(Cart cart);
        public string DeleteCart(int CartId);
        Cart GetCart(int CartId);
        List<Cart> GetAllCart();
        public IEnumerable<Cart> GetCartByUserID(int UserId);
        public int GetCartId(int UserId);
    }
}
