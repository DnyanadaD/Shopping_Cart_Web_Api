using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart_API.Models;
using ShoppingCart_API.Repository;

namespace ShoppingCart_API.Services
{
    public class AddressService
    {
        
         private IAddress _AddressRepository;
        public AddressService(IAddress AddressRepository)
        {
            _AddressRepository =AddressRepository;
        }
        public string SaveAddress(AddressT AddressT)
        {
            return _AddressRepository.SaveAddress(AddressT);
        }
        public string DeleteAddress(int AddressId)
        {
            return _AddressRepository.DeleteAddress(AddressId);
        }
        public string UpdateAddress(AddressT AddressT)
        {
            return _AddressRepository.UpdateAddress(AddressT);
        }
        public AddressT GetAddress(int AddressId)
        {
            return _AddressRepository.GetAddress(AddressId);
        }
        public AddressT GetUserAddress(int UserId)
        {
            return _AddressRepository.GetAddress(UserId);
        }
        public List<AddressT> GetAllAddress()
        {
            return _AddressRepository.GetAllAddress();
        }
         
    }
}
