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
    public class AddressController : Controller
    {
         
         private AddressService _addServices;
        public AddressController( AddressService addServices)
        {
            _addServices = addServices;
        }
        [HttpPost("SaveAddress")]
        public IActionResult SaveAddress(AddressT AddressT)
        {
            return Ok(_addServices.SaveAddress(AddressT));
        }

        [HttpDelete("DeleteAddress")]
        public IActionResult DeleteAddress(int AddressId)
        {
            return Ok(_addServices.DeleteAddress(AddressId));
        }

        [HttpPut("UpdateAddress")]
        public IActionResult UpdateAddress(AddressT AddressT)
        {
            return Ok(_addServices.UpdateAddress(AddressT));
        }

        [HttpGet("GetAddress")]
        public IActionResult GetAddress(int AddressId)
        {
            return Ok(_addServices.GetAddress(AddressId));
        }

        [HttpGet("GetUserAddress")]
        public IActionResult GetUserAddress(int UserId)
        {
            return Ok(_addServices.GetUserAddress(UserId));
        }

        [HttpGet("GetAllAddress")]
        public List<AddressT> GetAllAddress()
        {
            return _addServices.GetAllAddress();
        }
         
         

    }
}
