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
    public class PaymentController : Controller
    {
        public PaymentService _transactionServices;
        public PaymentController(PaymentService PaymentService)
        {
            _transactionServices = PaymentService;
        }
        [HttpPost("SaveTransaction")]
        public IActionResult SaveTransaction(Payment Payment)
        {
            return Ok(_transactionServices.SaveTransaction(Payment));
        }

        [HttpPost("DeleteTransaction")]
        public IActionResult DeleteTransaction(int CartId)
        {
            return Ok(_transactionServices.DeleteTransaction(CartId));
        }

        [HttpPost("UpdateTransaction")]
        public IActionResult UpdateTransaction(Payment transaction)
        {
            return Ok(_transactionServices.UpdateTransaction(transaction));
        }

        [HttpGet("GetTransaction")]
        public IActionResult GetTransaction(int TransactionId)
        {
            return Ok(_transactionServices.GetTransaction(TransactionId));
        }

        [HttpGet("GetAllTransaction")]
        public List<Payment> GetAllTransaction()
        {
            return _transactionServices.GetAllTransaction();
        }
    }
}
