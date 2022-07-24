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
    public class OrderController : Controller
    {
        
        private OrderService _orderDetailsServices;
        public OrderController(OrderService userDetailsServices)
        {
            _orderDetailsServices = userDetailsServices;
        }
        [HttpPost("SaveOrderDetails")]
        public IActionResult SaveOrderDetails(Order orderDetails)
        {
            return Ok(_orderDetailsServices.SaveOrderDetails(orderDetails));
        }

        [HttpDelete("DeleteOrderDetails")]
        public IActionResult DeleteOrderDetails(int OrderId)
        {
            return Ok(_orderDetailsServices.DeleteOrderDetails(OrderId));
        }

        [HttpPut("UpdateOrderDetails")]
        public IActionResult UpdateOrderDetails(Order orderDetails)
        {
            return Ok(_orderDetailsServices.UpdateOrderDetails(orderDetails));
        }

        [HttpGet("GetOrderDetails")]
        public IActionResult GetOrderDetails(int OrderId)
        {
            return Ok(_orderDetailsServices.GetOrderDetails(OrderId));
        }

        [HttpGet("GetAllOrderDetails()")]
        public List<Order> GetAllOrderDetails()
        {
            return _orderDetailsServices.GetAllOrderDetails();
        }
         
    }
}
