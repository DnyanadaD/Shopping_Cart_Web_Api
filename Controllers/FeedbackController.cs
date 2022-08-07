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
    public class FeedbackController : Controller
    {
        private FeedbackService _FeedDetailsServices;
        public FeedbackController(FeedbackService feedbackService)
        {
            _FeedDetailsServices = feedbackService;
        }
        [HttpPost("SaveFeedDetails")]
        public IActionResult SaveFeedDetails(feedback feedback)
        {
            return Ok(_FeedDetailsServices.SaveFeedDetails(feedback));
        }
        [HttpGet("GetAllFeedDetails()")]
        public List<feedback> GetAllFeedDetails()
        {
            return _FeedDetailsServices.GetAllFeedDetails();
        }
    }
}
