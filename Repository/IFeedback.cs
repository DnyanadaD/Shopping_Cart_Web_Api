using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart_API.Models;
namespace ShoppingCart_API.Repository
{
     public  interface IFeedback
    {
        public string SaveFeedDetails(feedback feedback);
        feedback GetFeedDetails(int UserId);
        List<feedback> GetAllFeedDetails();
    }
}
