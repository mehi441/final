using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalElectron.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public decimal Quantity { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public decimal Price { get; set; }

        [ForeignKey("ProductOption")]
        public int ProductOptionId { get; set; }
        public ProductOption ProductOption { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}