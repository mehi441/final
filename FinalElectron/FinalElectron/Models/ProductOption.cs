using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalElectron.Models
{
    public class ProductOption
    {

        public int Id { get; set; }

        [Column(TypeName = "money")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public decimal Price { get; set; }

        [Column(TypeName = "money")]
        public decimal OldPrice { get; set; }

        public DateTime AddedDate { get; set; }

        [ForeignKey("Color")]
        public int ColorId { get; set; }
        public Color Color { get; set; }

        [ForeignKey("Size")]
        public int SizeId { get; set; }
        public Size Size { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
         
        public List<OrderItem> OrderItems { get; set; }

        public List<Specification> Specifications { get; set; }
         
        public List<HotDeal> HotDeals { get; set; }

    }
}