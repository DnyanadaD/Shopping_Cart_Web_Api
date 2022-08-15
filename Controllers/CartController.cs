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
    public class CartController : Controller
    {
       
        private CartService _cartServices;
        public CartController(CartService cartServices)
        {
            _cartServices = cartServices;
        }
        [HttpPost("SaveCart")]
        public IActionResult SaveCart(Cart cart)
        {
            return Ok(_cartServices.SaveCart(cart));
        }

        [HttpDelete("DeleteCart")]
        public IActionResult DeleteCart(int CartId)
        {
            return Ok(_cartServices.DeleteCart(CartId));
        }

        [HttpPut("UpdateCart")]
        public IActionResult UpdateCart(Cart cart)
        {
            return Ok(_cartServices.UpdateCart(cart));
        }

        [HttpGet("GetCart")]
        public IActionResult GetCart(int CartId)
        {
            return Ok(_cartServices.GetCart(CartId));
        }

        [HttpGet("GetAllCart")]
        public List<Cart> GetAllCart()
        {
            return _cartServices.GetAllCart();
        }

        [HttpGet("GetCartHistory")]
        public IActionResult GetCartByUserID(int UserId)
        {
            return Ok(_cartServices.GetCartByUserID(UserId));
        }
        [HttpGet("GetCartId")]
        public IActionResult GetCartId(int UserId)
        {
            return Ok(_cartServices.GetCartId(UserId));
        }
    }
}
