using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart_API.Models;
using ShoppingCart_API.Repository;

namespace ShoppingCart_API.Services
{
    public class FeedbackService
    {
        public IFeedback _feedbackRepository;
        public FeedbackService(IFeedback FeedDetailsRepository)
        {
            _feedbackRepository = FeedDetailsRepository;
        }
        public string SaveFeedDetails(feedback feedback)
        {
            return _feedbackRepository.SaveFeedDetails(feedback);
        }

        public List<feedback> GetAllFeedDetails()
        {
            return _feedbackRepository.GetAllFeedDetails();
        }
    }

}

