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

        public DateTime EndDate { get; set; }
         
        public DateTime AddedDate { get; set; }

        [ForeignKey("ProductOption")]
        public int ProductOptionId { get; set; }
        public ProductOption ProductOption { get; set; }

        [NotMapped]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDateForm { get; set; }

         
        [NotMapped]
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }


    }
}