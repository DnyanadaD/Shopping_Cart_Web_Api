using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart_API.Models;
using ShoppingCart_API.Repository;

namespace ShoppingCart_API.Services
{
    public class PaymentService
    {
        public IPayment _transaction;
        public PaymentService(IPayment transaction)
        {
            _transaction = transaction;
        }
        public string SaveTransaction(Payment Payment)
        {
            return _transaction.SaveTransaction(Payment);
        }

        public string DeleteTransaction(int TransactionId)
        {
            return _transaction.DeleteTransaction(TransactionId);
        }
        public string UpdateTransaction(Payment Payment)
        {
            return _transaction.UpdateTransaction(Payment);
        }
        public Payment GetTransaction(int TransactionId)
        {
            return _transaction.GetTransaction(TransactionId);
        }
        public List<Payment> GetAllTransaction()
        {
            return _transaction.GetAllTransaction();
        }
    }
}
