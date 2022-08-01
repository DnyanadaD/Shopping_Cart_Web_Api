using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart_API.Models;
using ShoppingCart_API.Repository;
using ShoppingCart_API.Services;

namespace ShoppingCart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("GetUserbyEmail")]
        public IActionResult GetUserbyEmail(string EmailId)
        {
            return Ok(_userDetailsServices.GetUserbyEmail(EmailId));
        }

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

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(SignInModel model)
        {
            var user = _userDetailsServices.GetUserbyEmail(model.EmailId);
            if (user != null && model.Password == user.Password)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId", user.UserId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PNM4t3NEYbOd1SGe")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { message = "Email or Password is incorrect." });
            }


        }
    }
}
