using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace ShoppingCart_API.Models
{
    public class UserDetails
    {
        //public static object Claims { get; internal set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        
        [Required]
        public string Role { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        [DataType("varchar(30)")]
        [Required(ErrorMessage ="Email can not be empty")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile no. can not be empty")]
        public string MobileNumber { get; set; }
        
        [Required]
        public string AddressInfo { get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public string UserState { get; set; }
        
        [Required]
        public string Pincode { get; set; }

        [Required(ErrorMessage = "Password can not be empty")]
        public string Password { get; set; }

        [Required]
        public bool IsLogin { get; set; } = false;


    }
}
