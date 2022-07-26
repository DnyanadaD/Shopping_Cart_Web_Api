using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart_API.Models
{
    public class AddressT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int AddId { get; set; }

        [ForeignKey("UserDetails")]
        public int UserId { get; set; }
        public string AddressInfo { get; set; }
        public string City { get; set; }
        public string UserState { get; set; }
        public string Pincode { get; set; }

    }
}
