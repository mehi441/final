using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalElectron.Models
{
    public class HotDeal
    {
        public int Id { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
         
        [Required]
        public DateTime AddedDate { get; set; }

        [ForeignKey("ProductOption")]
        public int ProductOptionId { get; set; }
        public ProductOption ProductOption { get; set; }
    }
}