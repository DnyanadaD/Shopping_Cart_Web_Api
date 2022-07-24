using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart_API.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string Category { get; set; }

        [DataType("varchar(30)")]
        [Required(ErrorMessage = "Prouct name can not be empty")]
        public string ProductName { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
    }
}
