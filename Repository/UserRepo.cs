using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart_API.Data;
using ShoppingCart_API.Models;

namespace ShoppingCart_API.Repository
{
    public class UserRepo : IUser
    {
        private ShoppingCartDbContext _ShoppingCartDb;


        #region UserRepo
        /// <summary>
        /// UserRepo Constructor
        /// </summary>
        /// <param name="ShoppingCartDb"></param>
        public UserRepo(ShoppingCartDbContext ShoppingCartDb)
        {
            _ShoppingCartDb = ShoppingCartDb;
        }
        #endregion


        #region DeleteUserDetails
        /// <summary>
        ///  Function to Delete user details
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string DeleteUserDetails(int UserId)
        {
            string msg = "";
            UserDetails deleteUser = _ShoppingCartDb.UserDetails.Find(UserId); 
            try
            {
                if (deleteUser != null)
                {
                    _ShoppingCartDb.UserDetails.Remove(deleteUser);
                    _ShoppingCartDb.SaveChanges();
                    msg = "Deleted";
                }
            }
            catch (Exception) 
            {
                throw;
            }
            return msg;
        }
        #endregion



        #region GetAllUserDetails
        /// <summary>
        /// Function to get all users details
        /// </summary>
        /// <returns></returns>
        public List<UserDetails> GetAllUserDetails()
        {
            try
            {
                List<UserDetails> user = _ShoppingCartDb.UserDetails.ToList();
                return user;
            }
            catch(Exception)
            {
                throw;
            }
        }
        #endregion



        #region GetuserDetails
        /// <summary>
        /// This Function Will Give all the user Details
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public UserDetails GetUserDetails(int UserId)
        {
            try 
            {
                UserDetails user = _ShoppingCartDb.UserDetails.Find(UserId);
                return user;
            }
            catch(Exception)
            {
                throw;
            }
              
        }
        #endregion



        #region SaveUserDetails
        /// <summary>
        /// This Function Will Store the user Details
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        public string SaveUserDetails(UserDetails userDetails)
        {
            string result = string.Empty;
            try {
                _ShoppingCartDb.UserDetails.Add(userDetails);
                _ShoppingCartDb.SaveChanges();
                result= "Saved";
            }
            catch(Exception e) { }
   
            finally { }
            return result;
        }
        #endregion



        #region UpdateUserDetails
        /// <summary>
        /// UpdateUserDetails
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        public string UpdateUserDetails(UserDetails userDetails)
        {
            try 
            { 
            _ShoppingCartDb.Entry(userDetails).State = EntityState.Modified;
            _ShoppingCartDb.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return "Updated";
        }
        #endregion



        #region GetUserByEmail
        /// <summary>
        /// Method to get the user by Email
        /// </summary>
        /// <param name="EmailId"></param>
        /// <returns></returns>
        public UserDetails GetUserbyEmail(string EmailId)
        {
            UserDetails user = null;
            try
            {
                user = _ShoppingCartDb.UserDetails.FirstOrDefault(q => q.EmailId == EmailId);

            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }
        #endregion
    }
}
