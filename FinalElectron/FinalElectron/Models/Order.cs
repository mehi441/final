using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalElectron.Models
{
    public class Order
    {

        public int Id { get; set; }

        [Column(TypeName = "bit")]
        public bool IsDelivered { get; set; }

        [Column(TypeName = "bit")]
        public bool IsFreeShipping { get; set; }

        [Column(TypeName = "money")]
        public decimal ShippingPrice { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Note { get; set; }

        [Column(TypeName = "bit")]
        public bool PeymentMethod { get; set; }

        public DateTime AddedDate { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public UserAddress Address { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}