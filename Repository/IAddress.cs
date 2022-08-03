using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart_API.Models;
using ShoppingCart_API.Data;

namespace ShoppingCart_API.Repository
{
    public interface IAddress
    {
        public string SaveAddress(AddressT AdressT);
        public string UpdateAddress(AddressT AddressT);
        public string DeleteAddress(int AddressId);
        AddressT GetAddress(int AddressId);

        AddressT GetUserAddress (int UserId);
        List<AddressT> GetAllAddress();
    }
}
