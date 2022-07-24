using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart_API.Models;
using ShoppingCart_API.Repository;

namespace ShoppingCart_API.Services
{
    public class OrderService
    {
        
        private IOrder _orderDetailsRepository;
        public OrderService(IOrder orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }
        public string SaveOrderDetails(Order orderDetails)
        {
            return _orderDetailsRepository.SaveOrderDetails(orderDetails);
        }
        public string DeleteOrderDetails(int OrderId)
        {
            return _orderDetailsRepository.DeleteOrderDetails(OrderId);
        }
        public string UpdateOrderDetails(Order orderDetails)
        {
            return _orderDetailsRepository.UpdateOrderDetails(orderDetails);
        }
        public Order GetOrderDetails(int OrderId)
        {
            return _orderDetailsRepository.GetOrderDetails(OrderId);
        }
        public List<Order> GetAllOrderDetails()
        {
            return _orderDetailsRepository.GetAllOrderDetails();
        }
         
    }
}
