using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart_API.Models;

namespace ShoppingCart_API.Repository
{
    public interface IOrder
    {
        public string SaveOrderDetails(Order orderDetails);
        public string UpdateOrderDetails(Order orderDetails);
        public string DeleteOrderDetails(int OrderId);
        Order GetOrderDetails(int OrderId);
        List<Order> GetAllOrderDetails();
    }
}
