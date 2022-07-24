using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart_API.Data;
using ShoppingCart_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart_API.Repository
{
    public class OrderRepo : IOrder
    {
        private ShoppingCartDbContext _ShoppingCartDb;
        public OrderRepo(ShoppingCartDbContext ShoppingCartDb)
        {
            _ShoppingCartDb = ShoppingCartDb;
        }
        public string DeleteOrderDetails(int OrderId)
        {
            string msg = "";
            Order deleteOrder = _ShoppingCartDb.Order.Find(OrderId);
            if (deleteOrder != null)
            {
                _ShoppingCartDb.Order.Remove(deleteOrder);
                _ShoppingCartDb.SaveChanges();
                msg = "Deleted";
            }
            return msg;
        }

        public List<Order> GetAllOrderDetails()
        {
            List<Order> order = _ShoppingCartDb.Order.ToList();
            return order; 
        }

        public Order GetOrderDetails(int OrderId)
        {
            Order order = _ShoppingCartDb.Order.Find(OrderId);
            return order;
        }

        public string SaveOrderDetails(Order orderDetails)
        {
            _ShoppingCartDb.Order.Add(orderDetails);
            _ShoppingCartDb.SaveChanges();
            return "Saved";
        }

        public string UpdateOrderDetails(Order orderDetails)
        {
            _ShoppingCartDb.Entry(orderDetails).State = EntityState.Modified;
            _ShoppingCartDb.SaveChanges();
            return "Updated";
        }
    }
}
