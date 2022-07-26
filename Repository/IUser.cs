using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart_API.Models;

namespace ShoppingCart_API.Repository
{
    public interface IUser
    {
        public string SaveUserDetails(UserDetails userDetails);
        public string UpdateUserDetails(UserDetails userDetails);
        public string DeleteUserDetails(int UserId);
        UserDetails GetUserDetails(int UserId);
        List<UserDetails> GetAllUserDetails();
        UserDetails GetUserbyEmail(string EmailId);
    }
}
