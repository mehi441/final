using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalElectron.Models
{
    public class AdSlide
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [MaxLength(500)]
        [Required]
        public string Link { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }
    }
}