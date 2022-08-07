using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart_API.Data;
using ShoppingCart_API.Models;

namespace ShoppingCart_API.Repository
{
    public class FeedbackDetails : IFeedback
    {
        private ShoppingCartDbContext shoppingCartDb;

        public FeedbackDetails(ShoppingCartDbContext ShoppingDbContext)
        {
            shoppingCartDb = ShoppingDbContext;

        }
        public List<feedback> GetAllFeedDetails()
        {
            List<feedback> feed = shoppingCartDb.feedback.ToList();
            return feed;
        }

        public feedback GetFeedDetails(int UserId)
        {
            feedback feed = shoppingCartDb.feedback.Find(UserId);
            return feed;
        }

        public string SaveFeedDetails(feedback feedback)
        {
            shoppingCartDb.feedback.Add(feedback);
            shoppingCartDb.SaveChanges();
            return "Saved";
        }
    }
}
