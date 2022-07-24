using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart_API.Models
{
    public class UserDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        [DataType("varchar(30)")]
        [Required(ErrorMessage ="Email can not be empty")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile no. can not be empty")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Password can not be empty")]
        public string Password { get; set; }

    }
}
