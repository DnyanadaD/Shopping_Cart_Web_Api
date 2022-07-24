using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCart_API.Data;
using ShoppingCart_API.Models;

namespace ShoppingCart_API.Repository
{
    public class UserRepo : IUser
    {
        private ShoppingCartDbContext _ShoppingCartDb;
        public UserRepo(ShoppingCartDbContext ShoppingCartDb)
        {
            _ShoppingCartDb = ShoppingCartDb;
        }
        #region DeleteUserDetails
        /// <summary>
        ///  Function to Delete user details
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string DeleteUserDetails(int UserId)
        {
            string msg = "";
            UserDetails deleteUser = _ShoppingCartDb.UserDetails.Find(UserId);//storing the details of the vegetable in the obj 
            if (deleteUser != null)
            {
                _ShoppingCartDb.UserDetails.Remove(deleteUser);
                _ShoppingCartDb.SaveChanges();
                msg = "Deleted";
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
           
            List<UserDetails> user = _ShoppingCartDb.UserDetails.ToList();
            return user;
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
                UserDetails user = _ShoppingCartDb.UserDetails.Find(UserId);
                return user;   
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

            _ShoppingCartDb.Entry(userDetails).State = EntityState.Modified;
            _ShoppingCartDb.SaveChanges();
            return "Updated";
        }
        #endregion
    }
}
