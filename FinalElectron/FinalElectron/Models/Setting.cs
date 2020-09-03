using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalElectron.Models
{
    public class Setting
    {
        public int Id { get; set; }


        [MaxLength(200)]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        public DateTime OpenTime { get; set; }

        [Required]
        public DateTime CloseTime { get; set; }

        [Required]
        public int DiscountPercent { get; set; }

        [MaxLength(50)]
        [Required]
        public string PoweredBy { get; set; }

        [MaxLength(40)]
        [Required]
        public string Email { get; set; }

        [MaxLength(20)]
        [Required]
        public string Phone { get; set; }

        [MaxLength(150)]
        [Required]
        public string AddressFirst { get; set; }

        [MaxLength(150)]
        [Required]
        public string AddressSecond { get; set; }

     

    }
}