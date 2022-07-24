using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart_API.Models;
using ShoppingCart_API.Services;

namespace ShoppingCart_API.Controllers
{
    public class UserDetailsController : Controller
    {
        private UserDetailsServices _userDetailsServices;

        #region UserdetailsController
        /// <summary>
        /// This Is Usercontroller Constructor
        /// </summary>
        /// <param name="userDetailsServices"></param>
        public UserDetailsController(UserDetailsServices userDetailsServices)
        {
            _userDetailsServices = userDetailsServices;
        }
        #endregion

        #region GetallUserDetails
        /// <summary>
        /// function for getting all user details
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllUserDetails()")]
        public List<UserDetails> GetAllUserDetails()
        {
            return _userDetailsServices.GetAllUserDetails();
        }
        #endregion

        #region DeleteUseretails
        /// <summary>
        /// function for deleting user details
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpPost("DeleteUserDetails")]
        public IActionResult DeleteUserDetails(int UserId)
        {
            return Ok(_userDetailsServices.DeleteUserDetails(UserId));
        }
        #endregion

        #region GetUserDetails
        /// <summary>
        /// Controller class of Getuserdetails
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpGet("GetUserDetails")]
        public IActionResult GetUserDetails(int UserId)
        {
            return Ok(_userDetailsServices.GetUserDetails(UserId));
        }
        #endregion

        #region SaveUserDetails
        /// <summary>
        /// Controller class of SaveuserDetails
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        [HttpPost("SaveUserDetails")]
        public IActionResult SaveUserDetails(UserDetails userDetails)
        {
            return Ok(_userDetailsServices.SaveUserDetails(userDetails));
        }
        #endregion

        #region UpdateUserDetails
        /// <summary>
        /// Updating user details
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        [HttpPut("UpdateUserDetails")]
        public IActionResult UpdateUserDetails(UserDetails userDetails)
        {
            return Ok(_userDetailsServices.UpdateUserDetails(userDetails));
        }
        #endregion
    }
}
