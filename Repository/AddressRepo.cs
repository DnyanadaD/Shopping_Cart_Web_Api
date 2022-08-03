using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCart_API.Data;
using ShoppingCart_API.Models;

namespace ShoppingCart_API.Repository
{
    public class AddressRepo : IAddress

    {
        private ShoppingCartDbContext _ShoppingCartDb;

        public AddressRepo(ShoppingCartDbContext ShoppingCartDb)
        {
            _ShoppingCartDb = ShoppingCartDb;
        }
        public string DeleteAddress(int AddressId)
        {
            string msg = "";
            AddressT delete = _ShoppingCartDb.AddressT.Find(AddressId);//storing the details of the Product in the obj 
            if (delete != null)
            {
                _ShoppingCartDb.AddressT.Remove(delete);
                _ShoppingCartDb.SaveChanges();
                msg = "Deleted";
            }
            return msg;

        }

        public AddressT GetAddress(int AddressId)
        {
            AddressT Address = _ShoppingCartDb.AddressT.Find(AddressId);
            return Address;
        }

        public AddressT GetUserAddress(int UserId)
        {
            AddressT Address = _ShoppingCartDb.AddressT.Find(UserId);
            return Address;
        }

        public List<AddressT> GetAllAddress()
        {
            List<AddressT> Address = _ShoppingCartDb.AddressT.ToList();
            return Address;
        }



        public string SaveAddress(AddressT AddressT)
        {
            _ShoppingCartDb.AddressT.Add(AddressT);
            _ShoppingCartDb.SaveChanges();
            return "Saved";
        }

        public string UpdateAddress(AddressT AddressT)
        {
            _ShoppingCartDb.Entry(AddressT).State = EntityState.Modified;
            _ShoppingCartDb.SaveChanges();
            return "Updated";

        }
    }




}