using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCart_API.Data;
using ShoppingCart_API.Models;

namespace ShoppingCart_API.Repository
{
    public class PaymentRepo : IPayment
    {
        private ShoppingCartDbContext _ShoppingCartDb;

        public PaymentRepo(ShoppingCartDbContext ShoppingCartDb)
        {
            _ShoppingCartDb = ShoppingCartDb;
        }
        public string DeleteTransaction(int TransactionId)
        {
            string msg = "";
            Payment deleteTransaction = _ShoppingCartDb.Payment.Find(TransactionId);
            if (deleteTransaction != null)
            {
                _ShoppingCartDb.Payment.Remove(deleteTransaction);
                _ShoppingCartDb.SaveChanges();
                msg = "Deleted";
            }
            return msg;
        }

        public List<Payment> GetAllTransaction()
        {
            List<Payment> transactions = _ShoppingCartDb.Payment.ToList();
            return transactions;
        }

        public Payment GetTransaction(int TransactionId)
        {
            Payment transaction = _ShoppingCartDb.Payment.Find(TransactionId);
            return transaction;
        }

        public string SaveTransaction(Payment Payment)
        {
            _ShoppingCartDb.Payment.Add(Payment);
            _ShoppingCartDb.SaveChanges();
            return "Saved";
        }

        public string UpdateTransaction(Payment Payment)
        {
            _ShoppingCartDb.Entry(Payment).State = EntityState.Modified;
            _ShoppingCartDb.SaveChanges();
            return "Updated";
        }
    }
}
