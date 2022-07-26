using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart_API.Models;
using ShoppingCart_API.Repository;

namespace ShoppingCart_API.Services
{
    public class UserDetailsServices
    {
        private IUser _userDetailsRepository;


        public UserDetailsServices(IUser userDetailsRepository)
        {
            _userDetailsRepository = userDetailsRepository;
        }

        public string DeleteUserDetails(int UserId)
        {
            return _userDetailsRepository.DeleteUserDetails(UserId);
        }

        public string UpdateUserDetails(UserDetails userDetails)
        {
            return _userDetailsRepository.UpdateUserDetails(userDetails);
        }


        public UserDetails GetUserDetails(int UserId)
        {
            return _userDetailsRepository.GetUserDetails(UserId);
        }


        public List<UserDetails> GetAllUserDetails()
        {
            return _userDetailsRepository.GetAllUserDetails();
        }

        public string SaveUserDetails(UserDetails userDetails)
        {
            return _userDetailsRepository.SaveUserDetails(userDetails);
        }

        public UserDetails GetUserbyEmail(string EmailId)
        {
            return _userDetailsRepository.GetUserbyEmail(EmailId);
        }
    }
}
