using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalElectron.Models
{
    public class Wishlist
    {

        public int Id { get; set; }

        

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }


        [ForeignKey("ProductOption")]
        public int ProductOptionId { get; set; }
        public ProductOption ProductOption { get; set; }

    }
}