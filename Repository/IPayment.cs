using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart_API.Models;

namespace ShoppingCart_API.Repository
{
    public interface IPayment
    {
        public string SaveTransaction(Payment Payment);

        public string UpdateTransaction(Payment Payment);
        public string DeleteTransaction(int TransactionId);
        Payment GetTransaction(int TransactionId);
        List<Payment> GetAllTransaction();
    }
}
