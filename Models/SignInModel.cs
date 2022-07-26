using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart_API.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Email can not be empty")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Password can not be empty")]
        public string Password { get; set; }
    }
}
